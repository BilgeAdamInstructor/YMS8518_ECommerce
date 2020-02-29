var Home_Index = {
    Init: function () {
        $.ajax({
            type: "GET",
            url: "/module/userbar",
            data: [],
            success: Home_Index.ModuleUserBar_Callback,
            dataType: "html",
            contentType: "html"
        });
    },
    ModuleUserBar_Callback: function (result) {
        $("#Module-UserBar").html(result);
    }
};