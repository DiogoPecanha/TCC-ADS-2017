$(document).ready(function () {
    aplicaMascaraCamposDeData();
    aplicaMascaraCPF();
    aplicaMascaraTelefones();
});

function aplicaMascaraCPF() {
    $('#CPF').mask('000.000.000-00', { reverse: true, placeholder: "___.___.___-__" });
}

function aplicaMascaraCamposDeData() {
    $('.date').mask('00/00/0000', { placeholder: "__/__/____" });
}

function aplicaMascaraTelefones() {
    $('.tel').mask('(00) 0000-0000');
    $('.cel').mask('(00) 00000-0000');
}