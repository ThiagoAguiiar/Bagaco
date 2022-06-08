const button = document.querySelector('#enviar')
button.addEventListener('click', enviarEmail)

function email(e) {
    var tempParams = {
        to_email: document.querySelector('#email').value,
        msg: document.querySelector('#texto').value
    }

    emailjs.send('service_c1kti2o', 'template_iqs0b8t', tempParams).then(function (resp) {
        console.log('Sucesso', resp.status)
    })
}

function enviarEmail(e) {
    e.preventDefault()
    const inputEmail = document.querySelector('#email')
    const textMSG = document.querySelector('#texto')

    if (inputEmail.value == '' || textMSG.value == '' || inputEmail.value == ' ' || inputEmail.value == ' ') {
        Command: toastr["warning"]("É necessário preencher os dados corretamente", "Ops!")

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    } else {
        email()

        Command: toastr["success"]("Feedback enviado com sucesso", "Prontinho!")
        toastr.options = {
            "closeButton": false,
            "debug": true,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    }
}