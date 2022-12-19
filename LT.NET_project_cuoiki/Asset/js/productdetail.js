// Hiển thị hình ảnh chi tiết của sản phẩm
const allHoverImages = document.querySelectorAll('.hover_container div img');
const imgContainer = document.querySelector('.img_container');
window.addEventListener('DOMContentLoaded',() =>{
    allHoverImages[0].parentElement.classList.add('active');
});
allHoverImages.forEach((image) =>{
    image.addEventListener('mouseover',() =>{
        imgContainer.querySelector('img').src = image.src;
        resetActiveImg();
        image.parentElement.classList.add('active');
    });
});
function resetActiveImg(){
    allHoverImages.forEach((img) =>{
        img.parentElement.classList.remove('active');
    });
}
// Số lượng sản phẩm
$(".button").on("click", function() {

    var $button = $(this);
    var oldValue = $button.parent().find("input").val();

    if ($button.text() == "+") {
        var newVal = parseFloat(oldValue) + 1;
    } else {
        if (oldValue > 1) {
            var newVal = parseFloat(oldValue) - 1;
        } else {
            newVal = 1;
        }
    }

    $button.parent().find("input").val(newVal);

});
// Chuyển đổi tab
$(document).ready(function (){
    $('.tab-content-item').hide();
    $('.tab-content-item:first-child').fadeIn();
    $('.nav-tabs li').click(function (){
       //active nav tabs
        $('.nav-tabs li').removeClass('active');
        $(this).addClass('active');
        //show tab-content item
        let id_tab_content = $(this).children('a').attr('href');
        //alert
        $('.tab-content-item').hide();
        $(id_tab_content).fadeIn();
        return false;

    });
});
// Hiển thị sản phẩm liên quan
$(document).ready(function() {
    $('#autoWidth').lightSlider({
        autoWidth:true,
        loop:true,
        onSliderLoad: function() {
            $('#autoWidth').removeClass('cS-hidden');
        }
    });
});
//
// Hiển thị hướng dẫn đo size cho sản phầm nhẫn
var modal = document.getElementById("myModal");
var btn = document.getElementById("myBtn");
var span = document.getElementsByClassName("close")[0];

btn.onclick = function() {
    modal.style.display = "block";
}

span.onclick = function() {
    modal.style.display = "none";
}

window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}