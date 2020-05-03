﻿namespace BloodDanationSystem.Web.Areas.Identity.Pages.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using BloodDanationSystem.Common;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Messaging;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Extensions.Logging;

    [AllowAnonymous]
#pragma warning disable SA1649 // File name should match first type name
    public class RegisterModel : PageModel
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<RegisterModel> logger;
        private readonly IEmailSender emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [Display(Name = "Full Name")]
            public string FullName { get; set; }

            [Required]
            [Display(Name = "Age")]
            public int Age { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

#pragma warning disable SA1201 // Elements should appear in the correct order
        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
#pragma warning restore SA1201 // Elements should appear in the correct order
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                this.ReturnUrl = "/Identity/Account/Login";
                this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                return this.Page();
            }
            else
            {
                return this.Redirect("/");
            }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = "/Identity/Account/Login";
            this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (this.ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = this.Input.Username,
                    FullName = this.Input.FullName,
                    Email = this.Input.Email,
                    PasswordHash = this.Input.Password,
                    Age = this.Input.Age,
                };

                var emailExist = await this.userManager.GetEmailAsync(user);
                var usernameExist = await this.userManager.GetUserNameAsync(user);

                if (emailExist != null)
                {
                    this.ModelState.AddModelError(string.Empty, "User with email addresss already exists");
                }

                if (usernameExist != null)
                {
                    this.ModelState.AddModelError(string.Empty, "User with this username already exists");
                }
                else
                {
                    var result = await this.userManager.CreateAsync(user, this.Input.Password);

                    if (result.Succeeded)
                    {
                        this.logger.LogInformation("User created a new account with password.");

                        var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = this.Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = user.Id, code = code },
                            protocol: this.Request.Scheme);

                        string htmlMessage = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";
                        await this.emailSender.SendEmailConfirmationAsync(this.Input.Email, "Confirm your email", htmlMessage);

                        await this.userManager.AddToRoleAsync(user, GlobalConstants.UserRoleName);

                        return this.LocalRedirect(returnUrl);
                    }

                    foreach (var error in result.Errors)
                    {
                        this.ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return this.Page();
        }
    }
}
