$(function () {
    jQuery.validator.addMethod('validemail', function (value, element, params) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(value);
        
    }, '');

    jQuery.validator.unobtrusive.adapters.add('validemail', function (options) {
        options.rules['validemail'] = {};
        options.messages['validemail'] = options.message;
    });
}(jQuery));