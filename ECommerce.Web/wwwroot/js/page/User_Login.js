var User_Login = {
    Init: function () {},
    Login: {
        Login: function () {
            var email = $("#user-login-email").val();
            var password = $("#user-login-password").val();
            var rememberMe = $("#user-login-rememberme").prop("checked");

            if (!email || !Helper.Validation.IsEmail(email)) {
                Helper.UI.Alert("HATA", "E-posta adresiniz hatalı.", "error");
                return;
            }
            else if (!password || password.length < 8 || password.length > 64) {
                Helper.UI.Alert("HATA", "Şifreniz hatalı.", "error");
                return;
            }

            var data = { Email: email, Password: password, RememberMe: rememberMe };

            data = JSON.stringify(data);

            $.ajax({
                type: "POST",
                url: "/user/loginaction",
                data: data,
                success: User_Login.Login.Login_Callback,
                error: User_Login.Login.Login_Callback_Error,
                dataType: "json",
                contentType: "application/json; charset=utf-8;"
            });
        },
        Login_Callback: function (result) {
            window.location = "/";
        },
        Login_Callback_Error: function (result) {
            Helper.UI.Alert("HATA", result.responseText, "error");
        }
    },
    Register: {
        Register: function() {
            var name = $("#user-register-name").val();
            var surname = $("#user-register-surname").val();
            var email = $("#user-register-email").val();
            var password = $("#user-register-password").val();
            var password2 = $("#user-register-password2").val();

            if (!name || name.length < 2 || name.length > 50) {
                Helper.UI.Alert("Hata", "Adınız 2 karakterden kısa, 50 karakterden uzun olamaz.", "error");
                return;
            }
            else if (!surname || surname.length < 2 || surname.length > 50) {
                Helper.UI.Alert("Hata", "Soyadınız 2 karakterden kısa, 50 karakterden uzun olamaz.", "error");
                return;
            }
            else if (!email || email.length < 6 || email.length > 350 || !Helper.Validation.IsEmail(email)) {
                Helper.UI.Alert("Hata", "Email adresiniz 6 karakterden kısa, 350 karakterden uzun olamaz.", "error");
                return;
            }
            else if (!password || password.length < 8 || password.length > 64) {
                Helper.UI.Alert("Hata", "Şifreniz 8 karakterden kısa, 64 karakterden uzun olamaz.", "error");
                return;
            }
            else if (password != password2) {
                Helper.UI.Alert("Hata", "Şifreniz, tekrar şifreniz ile aynı olmalı.", "error");
                return;
            }

            //client side validation
            var data = { Name: name, Surname: surname, Password: password, Email: email };
            data = JSON.stringify(data);

            $.ajax({
                type: "POST",
                url: "/user/registeraction",
                data: data,
                success: User_Login.Register.Register_Callback,
                error: User_Login.Register.Register_Callback_Error,
                dataType: "json",
                contentType: "application/json; charset=utf-8;"
            });
        },
        Register_Callback: function(result) {
            window.location.reload();
        },
        Register_Callback_Error: function(result) {
            Helper.UI.Alert("Hata Oluştu", result.responseText, "error");
        }
    }
}