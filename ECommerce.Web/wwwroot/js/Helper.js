var Helper = {
    Module: {
        Init: function(name) {
            $.ajax({
                ModuleName: name,
                type: "GET",
                url: "/module/" + name,
                data: [],
                success: Helper.Module.Init_Callback,
                dataType: "html",
                contentType: "html"
            });
        },
        Init_Callback: function (result) {
            $("#Module-" + this.ModuleName).html(result);
        }
    }
};