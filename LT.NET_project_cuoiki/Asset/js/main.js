var searchBtn = document.querySelector('.search-btn');
var closeModalBtn = document.querySelector('.main-modal-close-btn button')
var HidemodalSearch = document.querySelector('.hide-modal-search')

var searchBtnRes = document.querySelector('.responsive .right_btn .search-btn')

var navBtnRes = document.querySelector('.responsive .navbar')

var closeBtn = document.querySelector('.closeBtn')

var toggleBtn = document.querySelectorAll('.main-menu-title i')

// Show/hide modal search
searchBtn.addEventListener('click', function () {
    console.log('ok')
    document.querySelector('.header_page-modal-search').style.transform = 'translateY(0)';
})

closeModalBtn.addEventListener('click', function (e) {
    document.querySelector('.header_page-modal-search').style.transform = 'translateY(-100%)';
})

HidemodalSearch.addEventListener('click', function (e) {
    document.querySelector('.header_page-modal-search').style.transform = 'translateY(-100%)';
})

// Show/hide modal search responsive
searchBtnRes.addEventListener('click', function () {
    document.querySelector('.header_page-modal-search').style.transform = 'translateY(0)';
})

// Toggle navication
navBtnRes.addEventListener('click', function () {
    document.querySelector('.category_header-responsive').style.transform = 'translateX(0)'
})

closeBtn.addEventListener('click', function () {
    document.querySelector('.category_header-responsive').style.transform = 'translateX(-100%)'
})

var content = document.querySelectorAll('.main-menu-content')
toggleBtn.forEach(function (b, ib) {
    b.addEventListener('click', function () {
        content.forEach(function (c, ic) {
            if (ib === ic) {
                c.classList.toggle('toggle')
                if (c.classList.contains('toggle')) {
                    c.style.display = 'block'
                    b.className = 'fa-solid fa-chevron-right'
                } else {
                    c.style.display = 'none'
                    b.className = 'fa-solid fa-chevron-down'
                }
            }
        })
    })

})




// srcoll
var prevScrollpos = window.pageYOffset;

// document.querySelector('.header_page').style.position = 'none';
document.querySelector('.header_page').classList.remove('sticky')

window.onscroll = function () {
    var currentScrollPos = window.pageYOffset;
    if (prevScrollpos > currentScrollPos) {
        document.querySelector('.header_page').classList.remove('sticky')
    } else {
        document.querySelector('.header_page').classList.add('sticky')
        document.querySelector('.header_page-modal-search').style.position = 'fixed'
    }
    prevScrollpos = currentScrollPos
}

