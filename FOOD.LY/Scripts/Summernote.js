$(document).ready(function () {
    //$('#summernote').summernote({
    //    placeholder: 'Hello stand alone ui',
    //    tabsize: 2,
    //    height: 120,
    //    toolbar: [
    //        ['style', ['style']],
    //        ['font', ['bold', 'underline', 'clear']],
    //        ['color', ['color']],
    //        ['para', ['ul', 'ol', 'paragraph']],
    //        ['table', ['table']],
    //        ['insert', ['link', 'picture', 'video']],
    //        ['view', ['fullscreen', 'codeview', 'help']]
    //    ]
    //});

    //$('#summernote').summernote();

    //$('#summernote').summernote({
    //    height: 300,                 // set editor height
    //    minHeight: null,             // set minimum height of editor
    //    maxHeight: null,             // set maximum height of editor
    //    focus: true                  // set focus to editable area after initializing summernote
    //});
    //$('#summernote').summernote('destroy');

    $('#summernote').summernote({
        minHeight: 200,
        placeholder: 'Write here ...',
        focus: false,
        airMode: false,
        fontNames: ['Roboto', 'Calibri', 'Times New Roman', 'Arial'],
        fontNamesIgnoreCheck: ['Roboto', 'Calibri'],
        dialogsInBody: true,
        dialogsFade: true,
        disableDragAndDrop: false,
        toolbar: [
            // [groupName, [list of button]]
            ['style', ['bold', 'italic', 'underline', 'clear']],
            ['para', ['style', 'ul', 'ol', 'paragraph']],
            ['fontsize', ['fontsize']],
			['table', ['table']],
            ['height', ['height']],
            ['misc', ['undo', 'redo', 'fullscreen']]
        ],
        popover: {
            air: [
                ['color', ['color']],
                ['font', ['bold', 'underline', 'clear']]
            ]
        },
        print: {
            //'stylesheetUrl': 'url_of_stylesheet_for_printing'
        }
    });
    $('#summernote2').summernote({ airMode: true, placeholder: 'Try the airmode' });
	$("#summernote").summernote("code", '<p style="line-height: 1;"><span style="font-size: 18px;">﻿</span><span style="font-size: 18px;">﻿</span><b><u><span style="font-size: 18px;">Ingredients&nbsp;:-</span></u></b></p><ul><li><span style="font-size: 14px;">E.g :- Oil</span></li><li><span style="font-size: 14px;">Tomato</span></li><li><span style="font-size: 14px;"><br></span></li></ul><p><span style="font-weight: bolder; font-size: 18px;"><u>Procedure :-</u></span></p><ul><li><span style="font-size: 14px;">E.g :- Cut Tomatoes, Onions</span></li><li><br></li></ul>');

});