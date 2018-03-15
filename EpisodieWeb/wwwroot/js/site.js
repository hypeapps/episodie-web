$(document).ready(function () {
    initSlickSlider();
});
// Funkcja inicjalizująca bibliotekę SLICK.
function initSlickSlider() {
    $('.col').slick({
        centerMode: false,
        centerPadding: '30px',
        slidesToShow: 8,
        slidesToScroll: 1,
        autoplay: false,
        draggable: true,
        swipe: true,
        swipeToSlide: true,
        variableWidth: true,
        infinite: false,
        arrows: true
    });
}