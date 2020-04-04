var Account_ChangePassword = {
    Init: function() {
    },
    Save: function() {
        var password = $("#account-changepassword-password").val();
        var newPassword = $("#account-changepassword-newpassword").val();
        var newPassword2 = $("#account-changepassword-newpassword2").val();

        if (newPassword != newPassword2) {
            Helper.UI.Alert("Hata", "Yeni şifre, tekrar şifresi ile aynı değil", "error");
        }
        else if (newPassword.length < 8 || newPassword.length > 64) {
            Helper.UI.Alert("Hata", "Yeni şifre 8 karakterden kısa 64 karakterden uzun olamaz", "error");
        }
        else if (password.length < 8 || password.length > 64) {
            Helper.UI.Alert("Hata", "Şu anki şifreniz 8 karakterden kısa 64 karakterden uzun olamaz", "error");
        } else {
            var data = { Password: password, NewPassword: newPassword };
            data = JSON.stringify(data);

            $.ajax({
                type: "POST",
                url: "/account/changepasswordaction",
                data: data,
                success: Account_ChangePassword.Save_Callback,
                error: Account_ChangePassword.Save_Callback_Error,
                dataType: "json",
                contentType: "application/json; charset=utf-8;"
            });
        }
    },
    Save_Callback: function(result) {
        Helper.UI.Alert("Başarılı", "Şifreniz başarıyla değiştirilmiştir", "success");
        $("#account-changepassword-newpassword").val("");
        $("#account-changepassword-newpassword2").val("");
        $("#account-changepassword-password").val("");
    },
    Save_Callback_Error: function (result) {
        Helper.UI.Alert("Hata", result.responseText, "error");
    }
};