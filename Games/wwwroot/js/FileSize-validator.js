
$.validator.addMethod('filesize', function (value, element, param) {
    console.log(this.optional(element));
    console.log(element.files[0].size <= param)
    return this.optional(element) || element.files[0].size <= param;
});