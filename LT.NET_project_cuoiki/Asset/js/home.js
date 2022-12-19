window.addEventListener('load', function () {

    // sliders
    var imgs = document.querySelectorAll('.body_page-slides-card a')
    var slider_main = document.querySelector('.body_page-slides-card')
    var sliderItemWidth = imgs[0].offsetWidth;
    var btnsChange = document.querySelectorAll('.body_page-slides-card-list-btn ul li')
    var index = 0;

    btnsChange[0].style.background = '#bc8247'
    setInterval(function () {
        index++;

        btnsChange.forEach(function (btn, indexBtn) {
            let currentindex = indexBtn
            if (index != currentindex) {
                btn.style.background = '#fff'
            }
        })

        if (index > imgs.length - 1) {
            index = 0;
        }
        btnsChange[parseInt(index)].style.background = '#bc8247'
        slider_main.style = `transform: translateX(${-1 * index * sliderItemWidth}px)`
    }, 3000)

    btnsChange.forEach(function (b, ib) {
        b.addEventListener('click', function () {
            btnsChange.forEach(b1 => b1.style.background = '#fff')
            b.style.background = '#bc8247'
            index = ib
            slider_main.style = `transform: translateX(${-1 * index * sliderItemWidth}px)`
        })
    })


})