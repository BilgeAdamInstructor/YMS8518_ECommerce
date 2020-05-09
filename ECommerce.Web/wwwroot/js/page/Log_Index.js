var Log_Index = {
    Init: function() {
        Log_Index.Fetch_Log();
    },
    Fetch_Log: function() {
        $.ajax({
            type: "GET",
            url: "/log/getir",
            data: [],
            dataType: "json",
            contentType: "application/json; charset=utf-8;",
            success: Log_Index.Fetch_Log_Callback
        });
    },
    Fetch_Log_Callback: function(result) {
        console.log(result);
		        var datatable = $('.kt-datatable').KTDatatable({
			// datasource definition
			data: {
				type: 'local',
				source: result,
				pageSize: 10,
			},

			// layout definition
			layout: {
				scroll: false, // enable/disable datatable scroll both horizontal and vertical when needed.
				// height: 450, // datatable's body's fixed height
				footer: false, // display/hide footer
			},

			// column sorting
			sortable: true,

			pagination: true,

			search: {
				input: $('#generalSearch'),
			},

			// columns definition
			columns: [
				{
					field: 'id',
					title: '#',
					sortable: true,
					width: 20,
					type: 'number'
				}, {
					field: 'controller',
					title: 'Controller',
				}, {
                    field: 'createDate',
                    title: 'Erişim Tarihi',
                    template: function(row) {
                        console.log("okokok");
                        var date = new Date(new Date(row.createDate).getTime() + (-new Date().getTimezoneOffset() * 60000));

                        return date.getHours() + ":" + date.getMinutes()  + ":" + date.getSeconds() +
                            " " + date.getDate() + "." + parseInt(date.getMonth()+1) + "." + date.getFullYear();
                    }
                },
                {
                    field: 'userId',
                    title: 'Kullanıcı',
                    template: function(row) {
                        if (row.userId) {
                            return row.user.name + " " + row.user.surname;
                        }
                    }
                }],
		});
    }
};