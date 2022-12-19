// difference address
var checkbox_add = document.querySelector('.difference');
var div_add = document.querySelector('#difference-Add');

checkbox_add.addEventListener('click', function () {
    if (checkbox_add.checked == true) {

        div_add.style.display = 'block';
    } else {
        div_add.style.display = 'none';
    }
})
//register
var checkBox_newAcc = document.querySelector('#newAccount');
var div_newAcc = document.querySelector('.newAccount');

checkBox_newAcc.addEventListener('click', function () {
    if (checkBox_newAcc.checked == true) {

        div_newAcc.style.display = 'block';
    } else {
        div_newAcc.style.display = 'none';
    }
})
// login
var login_span = document.querySelector('#login');
var div_login = document.querySelector('.checkout-login');

login_span.addEventListener('click', function (event) {

    if (div_login.style.display === 'none') {

        div_login.style.display = 'block';

    } else {
        div_login.style.display = 'none';
    }
})
// coupon
var coupon_span = document.querySelector('#coupon')
var coupon = document.querySelector('#useCoupon')

coupon_span.addEventListener('click', function () {
    if (coupon.style.display === 'none') {

        coupon.style.display = 'block';

    } else {
        coupon.style.display = 'none';
    }
})
// collapsible

if (content.style.display === "block") {
    content.style.display = "none";
} else {
    content.style.display = "block";
}

function payment(id) {
    var cliked = document.getElementById(id);
    var a = document.querySelector('.content' + cliked.id.substring(cliked.id.length - 1))
    var count = document.getElementsByClassName('show').length


    if (count > 0) {
        document.querySelector('.content1').classList.remove('show');
        document.querySelector('.content2').classList.remove('show');
        document.querySelector('.content3').classList.remove('show');
    }
    if (a.classList.contains('show')) {
        a.classList.remove('show')

    } else {
        a.classList.add('show')
    }

}



