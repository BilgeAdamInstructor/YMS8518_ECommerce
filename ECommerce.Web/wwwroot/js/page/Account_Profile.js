var Account_Profile = {
    Save: function () {
        var name = $("#account-profile-name").val();
        var surname = $("#account-profile-surname").val();
        var email = $("#account-profile-email").val();

        var data = { Name: name, Surname: surname, Email: email };

        data = JSON.stringify(data);

        $.ajax({
            type: "POST",
            url: "/account/profilesaveaction",
            data: data,
            dataType: "json",
            contentType: "application/json; charset=utf-8;",
            success: Account_Profile.Save_Callback
        });
    },
    Save_Callback: function (result) {
        location.reload();
    }
};