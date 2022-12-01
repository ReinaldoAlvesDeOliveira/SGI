function BuscarPorCep(cep) {
    if (cep.length == 8) {
        $.get(`https://viacep.com.br/ws/${cep}/json/`, function (cepData) {
            if (cepData.erro) {
                alert("Cep não encontrado")
            } else {
                $("#rua").val(cepData.logradouro);
                $("#cep").val(cepData.cep);
                $("#complemento").val(cepData.complemento);
                $("#bairro").val(cepData.bairro);
                $("#cidade").val(cepData.localidade);
                $("#estado").val(cepData.uf);
                $("#pais").val("Brasil");
            }
        });
    } else {
        alert("Cep inválido");
    }

}