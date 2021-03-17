const onRssUrlKeyUp = (event) => {
    if (event.keyCode === 13) {
        event.preventDefault();
        addToList();
    }
}

const onRssUrlAddClick = () => {
    addToList();
}


const addToList = () => {
    let regex = new RegExp('https://www.+/.+.xml$');
    var input = $('#rss-input').val();

    if (regex.test(input)) {
        var currentIndex = Number($('#current-index').val());
        $('#rss-list').append(`<li class="list-group-item">${input}</li>`);
        $('#rss-list-container').append(` <input type="hidden" name="RssUrls[${currentIndex}]" value="${input}" />`);
        $('#current-index').val(currentIndex + 1);
        $('#rss-input').val('');
    } else {
        toastr.error('Nie można dodać nowego RSS ', 'Nieprawidłowy adres RSS');
    }
}

const onSendClick = () => {
    toastr.info('Wysyłanie emaila jest w trakcie. Proszę czekać...', 'Wysłanie');
    $.post('api/rss/send', () => {
        toastr.success('Email został wysłany', 'Wysłanie');
    }).fail(() => {
        toastr.error('Wystąpił błąd podczas wysyłania emaila', 'Wysłanie');
    });
}

const onPreviewClick = () => {
    $.get('home/preview', (html) => {
        $('#email-preview').html(html);
        toastr.success('Pogląd emaila został załadowany', 'Podgląd');
    }).fail(() => {
        toastr.error('Wystąpił błąd podczas generowania podglądu', 'Podgląd');
    });
}

