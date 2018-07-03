app.factory('pluginsService', [function () {
    /**** IOS Switch  ****/
    function iosSwitch() {
        if ($('.js-switch').length) {
            setTimeout(function () {
                 $('.js-switch').each(function () {
                    var colorOn = '#18A689';
                    var colorOff = '#DFDFDF';
                    var switchery = new Switchery(this, {
                        color: colorOn,
                        secondaryColor: colorOff
                    });
                });
            }, 500);
        }
    }

    /* Manage Slider */
    function sliderIOS() {
        if ($('.slide-ios').length && $.fn.slider) {
            $('.slide-ios').each(function () {
                $(this).sliderIOS();
            });
        }
    }

    function timepicker() {
        $('.timepicker').each(function () {
            $(this).timepicker({
                isRTL: false,
                timeFormat: 'HH:mm'
            });
        });
    }

    function checkBox() {
          $(':checkbox:not(.js-switch, .switch-input, .switch-iphone, .onoffswitch-checkbox, .ios-checkbox), :radio').each(function () {

            var checkboxClass = $(this).attr('data-checkbox') ? $(this).attr('data-checkbox') : 'icheckbox_minimal-grey';
            var radioClass = $(this).attr('data-radio') ? $(this).attr('data-radio') : 'iradio_minimal-grey';

            //if (checkboxClass.indexOf('_line') > -1 || radioClass.indexOf('_line') > -1) {
                $(this).iCheck({
                    checkboxClass: checkboxClass,
                    radioClass: radioClass,
                    //insert: '<div class="icheck_line-icon"></div>' + $(this).attr("data-label")
                });
            //} else {
            //    $(this).iCheck({
            //        checkboxClass: checkboxClass,
            //        radioClass: radioClass
            //    });
            //}
        });
    }

    function inputSelect() {
        if ($.fn.select2) {
            setTimeout(function () {
                $('select').each(function () {
                    function format(state) {
                        var state_id = state.id;
                        if (!state_id) return state.text; // optgroup
                        var res = state_id.split("-");
                        if (res[0] == 'image') {
                            if (res[2]) return "<img class='flag' src='../images/flags/" + res[1].toLowerCase() + "-" + res[2].toLowerCase() + ".png' style='width:27px;padding-right:10px;margin-top: -3px;'/>" + state.text;
                            else return "<img class='flag' src='../images/flags/" + res[1].toLowerCase() + ".png' style='width:27px;padding-right:10px;margin-top: -3px;'/>" + state.text;
                        }
                        else {
                            return state.text;
                        }
                    }
                    $(this).select2({
                        formatResult: format,
                        formatSelection: format,
                        placeholder: $(this).data('placeholder') ? $(this).data('placeholder') : '',
                        allowClear: $(this).data('allowclear') ? $(this).data('allowclear') : true,
                        minimumInputLength: $(this).data('minimumInputLength') ? $(this).data('minimumInputLength') : -1,
                        minimumResultsForSearch: $(this).data('search') ? 1 : -1,
                        dropdownCssClass: $(this).data('style') ? 'form-white' : '',
                        language: "pt-BR"
                    });
                });

            }, 200);

            /* Demo Select Loading Data */
            function repoFormatResult(repo) {
                var markup = '<div class="row">' +
                   '<div class="col-md-2"><img class="img-responsive" src="' + repo.owner.avatar_url + '" /></div>' +
                   '<div class="col-md-10">' +
                      '<div class="row">' +
                         '<div class="col-md-6">' + repo.full_name + '</div>' +
                         '<div class="col-md-3"><i class="fa fa-code-fork"></i> ' + repo.forks_count + '</div>' +
                         '<div class="col-md-3"><i class="fa fa-star"></i> ' + repo.stargazers_count + '</div>' +
                      '</div>';
                if (repo.description) {
                    markup += '<div>' + repo.description + '</div>';
                }
                markup += '</div></div>';
                return markup;
            }
            function repoFormatSelection(repo) {
                return repo.full_name;
            }

            //if ($('#demo-loading-data').length) {
            //    $("#demo-loading-data").select2({
            //        placeholder: "Search for a repository",
            //        minimumInputLength: 1,
            //        ajax: { // instead of writing the function to execute the request we use Select2's convenient helper
            //            url: "https://api.github.com/search/repositories",
            //            dataType: 'json',
            //            quietMillis: 250,
            //            data: function (term, page) {
            //                return {
            //                    q: term, // search term
            //                };
            //            },
            //            results: function (data, page) { // parse the results into the format expected by Select2.
            //                // since we are using custom formatting functions we do not need to alter the remote JSON data
            //                return { results: data.items };
            //            },
            //            cache: true
            //        },
            //        initSelection: function (element, callback) {
            //            // the input tag has a value attribute preloaded that points to a preselected repository's id
            //            // this function resolves that id attribute to an object that select2 can render
            //            // using its formatResult renderer - that way the repository name is shown preselected
            //            var id = $(element).val();
            //            if (id !== "") {
            //                $.ajax("https://api.github.com/repositories/" + id, {
            //                    dataType: "json"
            //                }).done(function (data) { callback(data); });
            //            }
            //        },
            //        formatResult: repoFormatResult, // omitted for brevity, see the source of this page
            //        formatSelection: repoFormatSelection,  // omitted for brevity, see the source of this page
            //        dropdownCssClass: "bigdrop", // apply css that makes the dropdown taller
            //        escapeMarkup: function (m) { return m; } // we do not want to escape markup since we are displaying html in results
            //    });
            //}
        }
    }


    /* Date picker */
    function datepicker() {
        $('.date-picker').each(function () {
            $(this).datepicker({
                numberOfMonths: 1,
                isRTL: $('body').hasClass('rtl') ? true : false,
                prevText: '<i class="fa fa-angle-left"></i>',
                nextText: '<i class="fa fa-angle-right"></i>',
                showButtonPanel: false,
                language: 'pt-BR',
                //format: 'dd/MM/yyyy',
                //extraFormats: ['DD/MM/YYYY']
            });
        });
    }
    
    /****  Summernote Editor  ****/
    function editorSummernote() {
        if ($('.summernote').length && $.fn.summernote) {
            $('.summernote').each(function () {
                $(this).summernote({
                    height: 300,
                    airMode: $(this).data('airmode') ? $(this).data('airmode') : false,
                    airPopover: [
                        ["style", ["style"]],
                        ['color', ['color']],
                        ['font', ['bold', 'underline', 'clear']],
                        ['para', ['ul', 'paragraph']],
                        ['table', ['table']],
                        ['insert', ['link', 'picture']]
                    ],
                    toolbar: [
                        ["style", ["style"]],
                        ["style", ["bold", "italic", "underline", "clear"]],
                        ["fontsize", ["fontsize"]],
                        ["color", ["color"]],
                        ["para", ["ul", "ol", "paragraph"]],
                        ["height", ["height"]],
                        ["table", ["table"]],
                        ['view', ['codeview']],
                    ]
                });
            });
        }
    }

    function formValidation() {
        if ($('.form-validation').length && $.fn.validate) {
            /* We add an addition rule to show you. Example : 4 + 8. You can other rules if you want */
            $.validator.methods.operation = function (value, element, param) {
                return value == param;
            };
            $.validator.methods.customemail = function (value, element) {
                return /^([-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4})+$/.test(value);
            };
            $('.form-validation').each(function () {
                var formValidation = $(this).validate({
                    success: "valid",
                    submitHandler: function () { alert("Form is valid! We submit it") },
                    errorClass: "form-error",
                    validClass: "form-success",
                    errorElement: "div",
                    ignore: [],
                    rules: {
                        avatar: { extension: "jpg|png|gif|jpeg|doc|docx|pdf|xls|rar|zip" },
                        password2: { equalTo: '#password' },
                        calcul: { operation: 12 },
                        url: { url: true },
                        email: {
                            required: {
                                depends: function () {
                                    $(this).val($.trim($(this).val()));
                                    return true;
                                }
                            },
                            customemail: true
                        },
                    },
                    messages: {
                        name: { required: 'Enter your name' },
                        lastname: { required: 'Enter your last name' },
                        firstname: { required: 'Enter your first name' },
                        email: { required: 'Enter email address', customemail: 'Enter a valid email address' },
                        language: { required: 'Enter your language' },
                        mobile: { required: 'Enter your phone number' },
                        avatar: { required: 'You must upload your avatar' },
                        password: { required: 'Write your password' },
                        password2: { required: 'Write your password', equalTo: '2 passwords must be the same' },
                        calcul: { required: 'Enter the result of 4 + 8', operation: 'Result is false. Try again!' },
                        terms: { required: 'You must agree with terms' }
                    },
                    highlight: function (element, errorClass, validClass) {
                        $(element).closest('.form-control').addClass(errorClass).removeClass(validClass);
                    },
                    unhighlight: function (element, errorClass, validClass) {
                        $(element).closest('.form-control').removeClass(errorClass).addClass(validClass);
                    },
                    errorPlacement: function (error, element) {
                        if (element.hasClass("custom-file") || element.hasClass("checkbox-type") || element.hasClass("language")) {
                            element.closest('.option-group').after(error);
                        }
                        else if (element.is(":radio") || element.is(":checkbox")) {
                            element.closest('.option-group').after(error);
                        }
                        else if (element.parent().hasClass('input-group')) {
                            element.parent().after(error);
                        }
                        else {
                            error.insertAfter(element);
                        }
                    },
                    invalidHandler: function (event, validator) {
                        var errors = validator.numberOfInvalids();
                    }
                });
                $(".form-validation .cancel").click(function () {
                    formValidation.resetForm();
                });
            });
        }
    }


    return {
        inputSelect: inputSelect,
        init: function () {
            /****  Variables Initiation  ****/
            var doc = document;
            var docEl = document.documentElement;
            var $sidebar = $('.sidebar');
            var $mainContent = $('.main-content');
            var $sidebarWidth = $(".sidebar").width();
            var is_RTL = false;

            if ($('body').hasClass('rtl')) is_RTL = true;

            var oldIndex;
            if ($('.sortable').length && $.fn.sortable) {
                $(".sortable").sortable({
                    handle: ".panel-header",
                    start: function (event, ui) {
                        oldIndex = ui.item.index();
                        ui.placeholder.height(ui.item.height() - 20);
                    },
                    stop: function (event, ui) {
                        var newIndex = ui.item.index();

                        var movingForward = newIndex > oldIndex;
                        var nextIndex = newIndex + (movingForward ? -1 : 1);

                        var items = $('.sortable > div');

                        // Find the element to move
                        var itemToMove = items.get(nextIndex);
                        if (itemToMove) {

                            // Find the element at the index where we want to move the itemToMove
                            var newLocation = $(items.get(oldIndex));

                            // Decide if it goes before or after
                            if (movingForward) {
                                $(itemToMove).insertBefore(newLocation);
                            } else {
                                $(itemToMove).insertAfter(newLocation);
                            }
                        }
                    }
                });
            }
            
            formValidation();
            checkBox();
            iosSwitch();
            sliderIOS();
            inputSelect();
            datepicker();
            //timepicker();
        }
    }
}]);