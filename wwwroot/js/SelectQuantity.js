$(":checkbox").on("click", function () {

    var id = $(this).attr('id');
    if ($(this).is(':checked')) {
        $('#' + 'num_' + id ).removeAttr('disabled');
        console.log('unchecked');
    } else {
        $('#' + 'num_' + id).attr('disabled', 'disabled');
        console.log('checked');
    }
});