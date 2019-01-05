//'use strict';

///**
// * Translator for documentation pages.
// *
// * To enable translation you should include one of language-files in your index.html
// * after <script src='lang/translator.js' type='text/javascript'></script>.
// * For example - <script src='lang/ru.js' type='text/javascript'></script>
// *
// * If you wish to translate some new texts you should do two things:
// * 1. Add a new phrase pair ("New Phrase": "New Translation") into your language file (for example lang/ru.js). It will be great if you add it in other language files too.
// * 2. Mark that text it templates this way <anyHtmlTag data-sw-translate>New Phrase</anyHtmlTag> or <anyHtmlTag data-sw-translate value='New Phrase'/>.
// * The main thing here is attribute data-sw-translate. Only inner html, title-attribute and value-attribute are going to translate.
// *
// */
//window.SwaggerTranslator = {

//    _words:[],

//    translate: function(sel) {      
//      var $this = this;
//      sel = sel || '[data-sw-translate]';      

//      $(sel).each(function() {                
//        $(this).html($this._tryTranslate($(this).html()));

//        $(this).val($this._tryTranslate($(this).val()));
//        $(this).attr('title', $this._tryTranslate($(this).attr('title')));

//      });
//    },

//    _tryTranslate: function(word) {
//      return this._words[$.trim(word)] !== undefined ? this._words[$.trim(word)] : word;
//    },

//    learn: function(wordsMap) {
//      this._words = wordsMap;
//    }
//};

'use strict';

/**
 * Translator for documentation pages.
 *
 * To enable translation you should include one of language-files in your index.html
 * after <script src='lang/translator.js' type='text/javascript'></script>.
 * For example - <script src='lang/ru.js' type='text/javascript'></script>
 *
 * If you wish to translate some new texsts you should do two things:
 * 1. Add a new phrase pair ("New Phrase": "New Translation") into your language file (for example lang/ru.js). It will be great if you add it in other language files too.
 * 2. Mark that text it templates this way <anyHtmlTag data-sw-translate>New Phrase</anyHtmlTag> or <anyHtmlTag data-sw-translate value='New Phrase'/>.
 * The main thing here is attribute data-sw-translate. Only inner html, title-attribute and value-attribute are going to translate.
 *
 */
window.SwaggerTranslator = {
    _words: [],

    translate: function () {
        var $this = this;
        $('[data-sw-translate]').each(function () {
            $(this).html($this._tryTranslate($(this).html()));
            $(this).val($this._tryTranslate($(this).val()));
            $(this).attr('title', $this._tryTranslate($(this).attr('title')));
        });
    },

    _tryTranslate: function (word) {
        return this._words[$.trim(word)] !== undefined ? this._words[$.trim(word)] : word;
    },

    learn: function (wordsMap) {
        this._words = wordsMap;
    }
};


/* jshint quotmark: double */
window.SwaggerTranslator.learn({
    "Warning: Deprecated": "���棺�ѹ�ʱ",
    "Implementation Notes": "ʵ�ֱ�ע",
    "Response Class": "��Ӧ��",
    "Status": "״̬",
    "Parameters": "����",
    "Parameter": "����",
    "Value": "ֵ",
    "Description": "����",
    "Parameter Type": "��������",
    "Data Type": "��������",
    "Response Messages": "��Ӧ��Ϣ",
    "HTTP Status Code": "HTTP״̬��",
    "Reason": "ԭ��",
    "Response Model": "��Ӧģ��",
    "Request URL": "����URL",
    "Response Body": "��Ӧ��",
    "Response Code": "��Ӧ��",
    "Response Headers": "��Ӧͷ",
    "Hide Response": "������Ӧ",
    "Headers": "ͷ",
    "Try it out!": "��һ�£�",
    "Show/Hide": "��ʾ/����",
    "List Operations": "��ʾ����",
    "Expand Operations": "չ������",
    "Raw": "ԭʼ",
    "can't parse JSON.  Raw result": "�޷�����JSON. ԭʼ���",
    "Model Schema": "ģ�ͼܹ�",
    "Model": "ģ��",
    "apply": "Ӧ��",
    "Username": "�û���",
    "Password": "����",
    "Terms of service": "��������",
    "Created by": "������",
    "See more at": "�鿴���ࣺ",
    "Contact the developer": "��ϵ������",
    "api version": "api�汾",
    "Response Content Type": "��ӦContent Type",
    "fetching resource": "���ڻ�ȡ��Դ",
    "fetching resource list": "���ڻ�ȡ��Դ�б�",
    "Explore": "���",
    "Show Swagger Petstore Example Apis": "��ʾ Swagger Petstore ʾ�� Apis",
    "Can't read from server.  It may not have the appropriate access-control-origin settings.": "�޷��ӷ�������ȡ������û����ȷ����access-control-origin��",
    "Please specify the protocol for": "��ָ��Э�飺",
    "Can't read swagger JSON from": "�޷���ȡswagger JSON��",
    "Finished Loading Resource Information. Rendering Swagger UI": "�Ѽ�����Դ��Ϣ��������ȾSwagger UI",
    "Unable to read api": "�޷���ȡapi",
    "from path": "��·��",
    "server returned": "����������"
});


$(function () {
    window.SwaggerTranslator.translate();

    //�ı�api key
    window.swaggerUi.changApiKey = function (token) {
        swaggerUi.api.clientAuthorizations.add("key", new SwaggerClient.ApiKeyAuthorization("token", token, "header"));
    };
});