

$(document).ready(function () {
    $('#Cover').on('change', function () {
        console.log('enter display function');
        console.log(window.URL.createObjectURL(this.files[0]));
        $('.cover-preview').attr('src', window.URL.createObjectURL(this.files[0])).removeClass('d-none');
    });
});