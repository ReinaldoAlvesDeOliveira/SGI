// Call the dataTables jQuery plugin
function MontarTabela(url, coluna, model) {
    $('#dataTable').DataTable({
        ajax: {
            url: url,
            dataType: "json",
            dataSrc: function (data) {
                return data;
            },
        },
        columns: coluna,
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.1/i18n/pt-BR.json'
        },
        columnDefs: [
            {
                targets: -1,
                data: null,
                defaultContent: `<button class="btn btn-primary btn-editar" data-model="${model}">Editar</button>`,
            },
        ],
    });

    $(document).on('click', '.btn-editar', function () {
        var table = $('#dataTable').DataTable();
        var data = table.row($(this).parents('tr')).data();
        var model = $(this).data("model");
        window.location.href = `/${model}/atualizar/${data.id}`;
    });
}