
$(document).ready(function () {
    $('#login-trigger').click(function () {
        $(this).next('#login-content').slideToggle();
        $(this).toggleClass('active');

        if ($(this).hasClass('active')) $(this).find('span').html('&#x25B2;')
        else $(this).find('span').html('&#x25BC;')
    });

    var movies_settings = {
        rowCssPrefix: 'row-',
        colCssPrefix: 'col-',
        filmWidth: 220,
        filmHeight: 300,
        filmCss: 'film',
    };

    var init_films = function () {
        var str = [], filmNo, className;
        
        $.get("/Movies/Data", function (data) {
            var movies = data;
            prepare_movies(movies);
        });

        function prepare_movies(movies) {

            var j = 0;
            var licznik = 3;
            for (i = 0; i < movies.length; i++) {
                className = movies_settings.filmCss + ' ' + movies_settings.rowCssPrefix + i.toString();
                divName = movies_settings.filmCss + ' ' + movies_settings.colCssPrefix + i.toString();
                divOpis = 'opis' + ' ' + movies_settings.colCssPrefix + i.toString();

                str.push('<li class="' + className + '"' +
                    'style="top:' + (j * movies_settings.filmHeight).toString() + 'px;left:' + (i * movies_settings.filmWidth - (licznik - 3) * movies_settings.filmWidth).toString() + 'px">' +
                    '<div class="' + divName + '"><img src="images/' + movies[i].imgPath + '"/>' + '</div>' + '<div class="' + divOpis + '">' + movies[i].title + ',</br>' + movies[i].type + ',</br>' + movies[i].genre + ',</br>' +
                    "Ocena: " + movies[i].rating + '</div>' +
                    '<form action="/Home/Reservation" method="get">' + '<input type="hidden" name="film"  value="' + movies[i].id + '"/>' + '<input type="submit" value="Rezerwuj"/>' + '</form>' +
                    '</li>');
                if (licznik == i) {
                    licznik += 4;
                    j++;
                }
            }
            $('#place_filmy').html(str.join(''));
            $('#film').css("width", (movies_settings.filmWidth * 4));
            $('#film').css("height", (movies_settings.filmHeight * (licznik + 1) / 4));
        }
	
    }
    init_films();
});