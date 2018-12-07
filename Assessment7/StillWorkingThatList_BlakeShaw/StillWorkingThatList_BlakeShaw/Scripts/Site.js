$(document).ready(function () {
    $('#attendeeQuestions').hide();
    $('#notAttending').hide();
    $('input[name="Attending"]').change(function () {
        var radioValue = $('input[name="Attending"]:checked').val();
        if (radioValue == 'Yes') {
            $('#notAttending').hide();
            $('#attendeeQuestions').show();
        }
        else if (radioValue == 'No') {
            $('#notAttending').show();
            $('#attendeeQuestions').hide();
        }
    });
});