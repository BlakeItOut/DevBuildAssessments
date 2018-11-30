// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#attendeeQuestions').hide();
    $('#notAttending').hide();
    $('#Attending').change(function () {
        if (this.value == 'yes') {
            $('#notAttending').hide();
            $('#attendeeQuestions').show();
        }
        else if (this.value == 'no') {
            $('#notAttending').show();
            $('#attendeeQuestions').hide();
        }
    });
});
