$(function () {
  $('input, textarea').placeholder();
});
/*! http://mths.be/placeholder v2.0.6 by @mathias */
;(function (window, document, $) {
  var isInputSupported = 'placeholder' in document.createElement('input'),
    isTextareaSupported = 'placeholder' in document.createElement('textarea'), prototype = $.fn, valHooks = $.valHooks,
    hooks, placeholder;
  if (navigator.userAgent.indexOf('Opera/') != -1) {
    isInputSupported = isTextareaSupported = false;
  }
  if (isInputSupported && isTextareaSupported) {
    placeholder = prototype.placeholder = function () {
      return this;
    };
    placeholder.input = placeholder.textarea = true;
  } else {
    placeholder = prototype.placeholder = function () {
      var $this = this;
      $this.filter((isInputSupported ? 'textarea' : ':input') + '[placeholder]').not('.placeholder').bind({
        'focus.placeholder': clearPlaceholder,
        'blur.placeholder': setPlaceholder
      }).data('placeholder-enabled', true).trigger('blur.placeholder');
      return $this;
    };
    placeholder.input = isInputSupported;
    placeholder.textarea = isTextareaSupported;
    hooks = {
      'get': function (element) {
        var $element = $(element);
        return $element.data('placeholder-enabled') && $element.hasClass('placeholder') ? '' : element.value;
      }, 'set': function (element, value) {
        var $element = $(element);
        if (!$element.data('placeholder-enabled')) {
          return element.value = value;
        }
        if (value == '') {
          element.value = value;
          if (element != document.activeElement) {
            setPlaceholder.call(element);
          }
        } else if ($element.hasClass('placeholder')) {
          clearPlaceholder.call(element, true, value) || (element.value = value);
        } else {
          element.value = value;
        }
        return $element;
      }
    };
    isInputSupported || (valHooks.input = hooks);
    isTextareaSupported || (valHooks.textarea = hooks);
    $(function () {
      $(document).delegate('form', 'submit.placeholder', function () {
        var $inputs = $('.placeholder', this).each(clearPlaceholder);
        setTimeout(function () {
          $inputs.each(setPlaceholder);
        }, 10);
      });
    });
    $(window).bind('beforeunload.placeholder', function () {
      $('.placeholder').each(function () {
        this.value = '';
      });
    });
  }

  function args(elem) {
    var newAttrs = {}, rinlinejQuery = /^jQuery\d+$/;
    $.each(elem.attributes, function (i, attr) {
      if (attr.specified && !rinlinejQuery.test(attr.name)) {
        newAttrs[attr.name] = attr.value;
      }
    });
    return newAttrs;
  }

  function clearPlaceholder(event, value) {
    var input = this, $input = $(input), hadFocus;
    if (input.value == $input.attr('placeholder') && $input.hasClass('placeholder')) {
      hadFocus = input == document.activeElement;
      if ($input.data('placeholder-password')) {
        $input = $input.hide().next().show().attr('id', $input.removeAttr('id').data('placeholder-id'));
        if (event === true) {
          return $input[0].value = value;
        }
        $input.focus();
      } else {
        input.value = '';
        $input.removeClass('placeholder');
      }
      hadFocus && input.select();
    }
  }

  function setPlaceholder() {
    var $replacement, input = this, $input = $(input), $origInput = $input, id = this.id;
    if (input.value == '') {
      if (input.type == 'password') {
        if (!$input.data('placeholder-textinput')) {
          try {
            $replacement = $input.clone().attr({'type': 'text'});
          } catch (e) {
            $replacement = $('<input>').attr($.extend(args(this), {'type': 'text'}));
          }
          $replacement.removeAttr('name').data({
            'placeholder-password': true,
            'placeholder-id': id
          }).bind('focus.placeholder', clearPlaceholder);
          $input.data({'placeholder-textinput': $replacement, 'placeholder-id': id}).before($replacement);
        }
        $input = $input.removeAttr('id').hide().prev().attr('id', id).show();
      }
      $input.addClass('placeholder');
      $input[0].value = $input.attr('placeholder');
    } else {
      $input.removeClass('placeholder');
    }
  }
}(this, document, jQuery));
