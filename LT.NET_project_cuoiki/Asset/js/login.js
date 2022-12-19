var registerBtn = document.querySelector('#register-button-login')
var loginBtn = document.querySelector('#login-button-register')
var registerModal = document.querySelector('.modal')
var registerModalContent = document.querySelector('.modal-content')
var close = document.getElementById('closeButton');
var modal = document.querySelector('.modal')

registerBtn.addEventListener('click', function (event) {
    event.preventDefault();
    registerModal.style.visibility = 'visible';
    registerModal.style.opacity = '1';
})

registerBtn.addEventListener('click', function (event) {
    event.preventDefault();
    registerModalContent.style.visibility = 'visible';
    registerModalContent.style.transform = 'scale(1)';
    registerModalContent.style.opacity = '1';
})
loginBtn.addEventListener('click', function (event) {
    event.preventDefault();
    registerModal.style.visibility = 'hidden';
    registerModal.style.opacity = '0';
    registerModalContent.style.visibility = 'hidden';
    registerModalContent.style.transform = 'scale(.5)';
    registerModalContent.style.opacity = '0';
})
loginBtn.addEventListener('click', function (event) {
    event.preventDefault();
    registerModal.style.visibility = 'hidden';
    registerModal.style.opacity = '0';
    registerModalContent.style.visibility = 'hidden';
    registerModalContent.style.transform = 'scale(.5)';
    registerModalContent.style.opacity = '0';
})
close.addEventListener('click', function (event) {
    event.preventDefault();
    registerModal.style.visibility = 'hidden';
    registerModal.style.opacity = '0';
    registerModalContent.style.visibility = 'hidden';
    registerModalContent.style.transform = 'scale(.5)';
    registerModalContent.style.opacity = '0';
})

window.addEventListener('click', function (event) {
    if (event.target == modal) {
        registerModal.style.visibility = 'hidden';
        registerModal.style.opacity = '0';
        registerModalContent.style.visibility = 'hidden';
        registerModalContent.style.transform = 'scale(.5)';
        registerModalContent.style.opacity = '0';
    }

})

// 

var email = document.querySelector("#email")
var pass = document.querySelector("#pass")
var loginBtn = document.querySelector(".login-button")

var uname = document.querySelector('#uname')
var email_register = document.querySelector('#email-register')
var pass_register = document.querySelector('#pass-register')

// 
const validateEmail = (email) => {
    const regex =
        /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i
    return email.match(regex)
}

// 
const showErrorMessage = (i, message) => {
    i.style.border = '2px solid red'
    i.setAttribute('placeholder', message)
}
const showSuccessMessage = (i, message) => {
    i.style.border = '2px solid #eaedff'
    i.setAttribute('placeholder', message)
}

// check login
email.addEventListener('input', () => {
    var emailValue = email.value
    if (!validateEmail(emailValue)) {
        showErrorMessage(email, "Email không hợp lệ!")
    } else {
        showSuccessMessage(email)
    }
})

pass.addEventListener('input', () => {
    var passValue = pass.value
    if (passValue.length < 8 || passValue.length > 16) {
        showErrorMessage(pass, 'Mật khẩu tối thiểu 8 kí tự và tối đa 16 kí tự')
    } else {
        showSuccessMessage(pass)
    }
})

// check register
uname.addEventListener('input', () => {
    var unameValue = uname.value
    if(unameValue.length < 8){
        showErrorMessage(uname, 'Tên đăng nhập phải có độ dài tối thiểu 8 kí tự')
    }else{
        showSuccessMessage(uname)
    }
})

email_register.addEventListener('input', () => {
    var email_registerValue = email_register.value
    if (!validateEmail(email_registerValue)) {
        showErrorMessage(email_register, "Email không hợp lệ!")
    } else {
        showSuccessMessage(email_register)
    }
})

pass_register.addEventListener('input', () => {
    var pass_registerValue = pass_register.value
    if (pass_registerValue.length < 8 || pass_registerValue.length > 16) {
        showErrorMessage(pass_register, 'Mật khẩu tối thiểu 8 kí tự và tối đa 16 kí tự')
    } else {
        showSuccessMessage(pass_register)
    }
})


