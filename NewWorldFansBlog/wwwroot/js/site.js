/*!
* Start Bootstrap - Clean Blog v6.0.7 (https://startbootstrap.com/theme/clean-blog)
* Copyright 2013-2021 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-clean-blog/blob/master/LICENSE)
*/
var shouldResetPage = false;

window.addEventListener('DOMContentLoaded', () => {
    let scrollPos = 0;
    const mainNav = document.getElementById('mainNav');
    const headerHeight = mainNav.clientHeight;
    window.addEventListener('scroll', function () {
        const currentTop = document.body.getBoundingClientRect().top * -1;
        if (currentTop < scrollPos) {
            // Scrolling Up
            if (currentTop > 0 && mainNav.classList.contains('is-fixed')) {
                mainNav.classList.add('is-visible');
            } else {
                console.log(123);
                mainNav.classList.remove('is-visible', 'is-fixed');
            }
        } else {
            // Scrolling Down
            mainNav.classList.remove(['is-visible']);
            if (currentTop > headerHeight && !mainNav.classList.contains('is-fixed')) {
                mainNav.classList.add('is-fixed');
            }
        }
        scrollPos = currentTop;
    });
})

var applyFilter = function (selectedFilter) {
    const newUrl = "/RedditPosts/RenderPostList?selectedFilter=" + selectedFilter;
    $.ajax({
        url: newUrl,
        type: 'GET',
        success: function (data) {
            window.history.replaceState({}, newUrl, newUrl);
            $('#prevLink').addClass('d-none');
            shouldResetPage = true;
            //remove all
            $('#filterNew').removeClass('btn-outline-light');
            $('#filterTop').removeClass('btn-outline-light');
            $('#filterBest').removeClass('btn-outline-light');
            $('#filterHot').removeClass('btn-outline-light');
            $('#filterNew').removeClass('btn-light');
            $('#filterTop').removeClass('btn-light');
            $('#filterBest').removeClass('btn-light');
            $('#filterHot').removeClass('btn-light');
            switch (selectedFilter) {
                case "New":
                    $('#filterNew').addClass('btn-light');
                    $('#filterTop').addClass('btn-outline-light');
                    $('#filterBest').addClass('btn-outline-light');
                    $('#filterHot').addClass('btn-outline-light');
                    break;
                case "Top":
                    $('#filterNew').addClass('btn-outline-light');
                    $('#filterTop').addClass('btn-light');
                    $('#filterBest').addClass('btn-outline-light');
                    $('#filterHot').addClass('btn-outline-light');
                    break;
                case "Best":
                    $('#filterNew').addClass('btn-outline-light');
                    $('#filterTop').addClass('btn-outline-light');
                    $('#filterBest').addClass('btn-light');
                    $('#filterHot').addClass('btn-outline-light');
                    break;
                case "Hot":
                    $('#filterNew').addClass('btn-outline-light');
                    $('#filterTop').addClass('btn-outline-light');
                    $('#filterBest').addClass('btn-outline-light');
                    $('#filterHot').addClass('btn-light');
                    break;
            }
            $('#postList').replaceWith(data);
        }
    });
};

var loadPosts = function (page, direction) {
    const selectedFilter = $('.btn-light').data('filter');
    const postName = direction === 'After' ? $('.post-preview').last().data('post-name') : $($('.post-preview')[1]).data('post-name');
    var p = page;
    if (shouldResetPage) {
        p = 2;
    }
    window.location.replace("/RedditPosts?page=" + p + "&direction=" + direction + "&postName=" + postName + "&selectedFilter=" + selectedFilter);
}