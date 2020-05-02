var Category_Manage = {
    CategoryId: 0,
    Init: function(categoryId) {
        Category_Manage.CategoryId = categoryId;
        Category_Manage.Fetch_Menu();
    },
    Fetch: function(categoryId) {
        if (categoryId == 0) return;

        $.ajax({
            type: "GET",
            url: "/kategori/getir/" + categoryId,
            data: [],
            dataType: "json",
            contentType: "application/json; charset=utf-8;",
            success: Category_Manage.Fetch_Callback
        });
    },
    Fetch_Callback: function(result) {
        console.log(result);
        $("#category-manage-categoryname").val(result.name);
    },
    Fetch_Menu: function() {
        $.ajax({
            type: "GET",
            url: "/menu/getir",
            data: [],
            dataType: "json",
            contentType: "application/json; charset=utf-8;",
            success: Category_Manage.Fetch_Menu_Callback
        });
    },
    Fetch_Menu_Callback: function(result) {
        console.log(result);
        var menuDom = $("#category-manage-menuid");

        var html = "";
        html += "<option value=\"0\">Menü Yok</option>";

        for (var i = 0; i < result.length; i++) {
            var menu = result[i];
            html += "<option value=\"" + menu.id + "\">" + menu.name + "</option>";
        }

        menuDom.html(html);

        Category_Manage.Fetch_Category();
    },
    Fetch_Category: function() {
        $.ajax({
            type: "GET",
            url: "/kategori/getir",
            data: [],
            dataType: "json",
            contentType: "application/json; charset=utf-8;",
            success: Category_Manage.Fetch_Category_Callback
        });
    },
    Fetch_Category_Callback: function(result) {
        console.log(result);

        var parentCategoryDom = $("#category-manage-parentcategoryid");

        var html = "";
        html += "<option value=\"0\">Kategori Yok</option>";

        for (var i = 0; i < result.length; i++) {
            var parentCategory = result[i];
            html += "<option value=\"" + parentCategory.id + "\">" + parentCategory.name + "</option>";
        }

        parentCategoryDom.html(html);

        Category_Manage.Fetch(Category_Manage.CategoryId);
    },
    Save: function() {
        var name = $("#category-manage-categoryname").val();
        var menuId = $("#category-manage-menuid").val();
        var parentCategoryId  = $("#category-manage-parentcategoryid").val();

        var data = { Name: name, MenuId: menuId, ParentCategoryId: parentCategoryId, CategoryId: Category_Manage.CategoryId };

        $.ajax({
            type: "POST",
            url: "/kategori/kaydet/",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8;",
            success: Category_Manage.Save_Callback
        });
    },
    Save_Callback: function(result) {
        console.log(result);
    }
}