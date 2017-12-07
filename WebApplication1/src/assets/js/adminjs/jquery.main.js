$(function () {
  jQuery('form').customForm();
  OpenBox({
    wrap: '.wrap-drop',
    link: '.btn-open',
    box: '.dropdown',
    openClass: 'open'
  });
});

function OpenBox(obj) {
  $(obj.wrap).each(function () {
    var hold = $(this);
    var link = hold.find(obj.link);
    var box = hold.find(obj.box);
    var w = obj.w;
    var close = hold.find(obj.close);

    link.click(function () {
      $(obj.wrap).not(hold).removeClass(obj.openClass);
      if (!hold.hasClass(obj.openClass)) {
        hold.addClass(obj.openClass);
      }
      else {
        hold.removeClass(obj.openClass);
      }
      return false;
    });

    hold.hover(function () {
      $(this).addClass('hovering');
    }, function () {
      $(this).removeClass('hovering');
    });

    $("body").click(function () {
      if (!hold.hasClass('hovering')) {
        hold.removeClass(obj.openClass);
      }
    });
    close.click(function () {
      hold.removeClass(obj.openClass);

      return false;
    });
  });
}

/**
 * jQuery Custom Form min v1.4.2
 * Copyright (c) 2014 JetCoders
 * email: yuriy.shpak@jetcoders.com
 * www: JetCoders.com
 * Licensed under the MIT License:
 * http://www.opensource.org/licenses/mit-license.php
 **/

;jQuery.fn.customForm = jQuery.customForm = function (_options) {
  var _this = this;
  var methods = {
    destroy: function () {
      var elements;
      if (typeof this === "function") elements = $("select, input:radio, input:checkbox"); else elements = this.add(this.find("select, input:radio, input:checkbox"));
      elements.each(function () {
        var data = $(this).data("customForm");
        if (data) {
          $(this).removeClass("outtaHere");
          if (data["events"]) data["events"].unbind(".customForm");
          if (data["create"]) data["create"].remove();
          if (data["resizeElement"]) data.resizeElement =
            false;
          $(this).unbind(".customForm")
        }
      })
    }, refresh: function () {
      if (typeof this === "function") $("select, input:radio, input:checkbox").trigger("refresh"); else this.trigger("refresh")
    }
  };
  if (typeof _options === "object" || !_options) {
    if (typeof _this == "function") _this = $(document);
    var options = jQuery.extend(true, {
      select: {
        elements: "select.customSelect",
        structure: '<div class="selectArea"><a tabindex="-1" href="#" class="selectButton"><span></span><span class="right">&nbsp;</span></a><div class="disabled"></div></div>',
        text: "span:first",
        btn: ".selectButton",
        optStructure: '<div class="selectOptions"><ul></ul></div>',
        maxHeight: false,
        topClass: "position-top",
        optList: "ul",
        nativeDrop: false
      },
      radio: {
        elements: "input.customRadio",
        structure: "<div></div>",
        defaultArea: "radioArea",
        checked: "radioAreaChecked"
      },
      checkbox: {
        elements: "input.customCheckbox",
        structure: "<div></div>",
        defaultArea: "checkboxArea",
        checked: "checkboxAreaChecked"
      },
      mobile: /(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od|ad)|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent ||
        navigator.vendor || window.opera) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test((navigator.userAgent ||
        navigator.vendor || window.opera).substr(0, 4)),
      disabled: "disabled",
      hoverClass: "hover"
    }, _options);
    return _this.each(function () {
      var hold = jQuery(this);
      var reset = jQuery();
      if (this !== document) reset = hold.find("input:reset, button[type=reset]");
      initSelect(hold.find(options.select.elements), hold, reset);
      initRadio(hold.find(options.radio.elements), hold, reset);
      initCheckbox(hold.find(options.checkbox.elements), hold, reset)
    })
  } else if (methods[_options]) methods[_options].apply(this);

  function initSelect(elements, form,
                      reset) {
    elements.not(".outtaHere").each(function () {
      var select = $(this);
      var replaced = jQuery(options.select.structure);
      var selectText = replaced.find(options.select.text);
      var selectBtn = replaced.find(options.select.btn);
      var selectDisabled = replaced.find("." + options.disabled).hide();
      var optHolder = jQuery(options.select.optStructure);
      var optList = optHolder.find(options.select.optList);
      var html = "";
      var optTimer, time;
      if (select.prop("disabled")) selectDisabled.show();
      if (options.mobile) select.addClass("mobile");

      function createStructure() {
        html =
          "";
        select.find("option").each(function () {
          var selOpt = jQuery(this);
          if (selOpt.prop("selected") && !select.data("placeholder")) selectText.html(selOpt.html()).addClass(selOpt.attr("class"));
          html += '<li data-value="' + selOpt.val() + '" class="' + (selOpt.attr("class") ? selOpt.attr("class") : "") + " " + (selOpt.prop("selected") ? "selected" : "") + '">' + (selOpt.prop("disabled") ? "<span>" : '<a href="#">') + selOpt.html() + (selOpt.prop("disabled") ? "</span>" : "</a>") + "</li>"
        });
        if (select.data("placeholder")) {
          selectText.html(select.data("placeholder"));
          replaced.addClass("placeholder");
          select.val("-")
        }
        optList.append(html).find("a").click(function () {
          replaced.removeClass("placeholder");
          select.val(jQuery(this).parent().data("value").toString());
          select.change();
          replaced.removeClass(options.hoverClass);
          optHolder.css({left: -9999, top: -9999});
          return false
        });
        if (select.data("customForm") !== undefined && select.data("customForm")["resizeElement"]) select.data("customForm").resizeElement()
      }

      createStructure();
      replaced.width(select.outerWidth());
      replaced.insertBefore(select);
      replaced.addClass(select.attr("class"));
      optHolder.css({width: select.outerWidth(), position: "absolute", left: -9999, top: -9999});
      optHolder.addClass(select.attr("class"));
      jQuery(document.body).append(optHolder);
      select.bind("refresh", function () {
        optList.empty();
        createStructure()
      });
      replaced.hover(function () {
        if (optTimer) clearTimeout(optTimer)
      }, function () {
        optTimer = setTimeout(function () {
          replaced.removeClass(options.hoverClass);
          optHolder.css({left: -9999, top: -9999})
        }, 200)
      });
      optHolder.hover(function () {
          if (optTimer) clearTimeout(optTimer)
        },
        function () {
          optTimer = setTimeout(function () {
            replaced.removeClass(options.hoverClass);
            optHolder.css({left: -9999, top: -9999})
          }, 200)
        });
      if (options.select.maxHeight && optHolder.children().height() > options.select.maxHeight) optHolder.children().css({
        height: options.select.maxHeight,
        overflow: "auto"
      });
      if (options.mobile) $(document).bind("touchstart.customForm", function (e) {
        if (!($(e.target).parents().index(optHolder) != -1 || $(e.target).index(optHolder) != -1)) {
          replaced.removeClass(options.hoverClass);
          optHolder.css({
            left: -9999,
            top: -9999
          })
        }
      });
      selectBtn.click(function () {
        if (optHolder.offset().left > 0) {
          replaced.removeClass(options.hoverClass);
          optHolder.css({left: -9999, top: -9999})
        } else if (!(options.select.nativeDrop && options.mobile)) openDrop();
        return false
      });
      reset.click(function () {
        setTimeout(function () {
          select.find("option").each(function (i) {
            var selOpt = jQuery(this);
            if (selOpt.val() == select.val()) {
              selectText.html(selOpt.html());
              optList.find("li").removeClass("selected");
              optList.find("li").eq(i).addClass("selected")
            }
          })
        }, 10)
      });
      var openDrop =
        function () {
          replaced.addClass(options.hoverClass);
          select.attr("style", "height: 0 !important;").removeClass("outtaHere");
          optHolder.css({width: select.outerWidth(), top: -9999});
          select.addClass("outtaHere").removeAttr("style");
          if (options.select.maxHeight && optHolder.children().height() > options.select.maxHeight) optHolder.children().css({
            height: options.select.maxHeight,
            overflow: "auto"
          });
          if ($(window).height() + $(window).scrollTop() > optHolder.outerHeight(true) + replaced.offset().top + replaced.outerHeight()) {
            optHolder.removeClass(options.select.topClass).css({
              top: replaced.offset().top +
              replaced.outerHeight(), left: replaced.offset().left
            });
            replaced.removeClass(options.select.topClass)
          } else {
            optHolder.addClass(options.select.topClass).css({
              top: replaced.offset().top - optHolder.outerHeight(true),
              left: replaced.offset().left
            });
            replaced.addClass(options.select.topClass)
          }
          select.focus();
          changeSelect()
        };
      var changeSelect = function (e) {
        e = e ? e : {};
        select.find("option").each(function (i) {
          var selOpt = jQuery(this);
          if (selOpt.val() == select.val()) {
            selectText.html(selOpt.html());
            selectText.removeClass().addClass(selOpt.attr("class") ?
              selOpt.attr("class") : "");
            optList.find("li").removeClass("selected");
            optList.find("li").eq(i).addClass("selected")
          }
        });
        if (optList.css("overflow") != "hidden") {
          if (optList.scrollTop() > optList.find("li.selected").position().top + optList.scrollTop()) optList.scrollTop(optList.find("li.selected").position().top + optList.scrollTop());
          if (optList.scrollTop() + optList.height() < optList.find("li.selected").position().top + optList.find("li.selected").outerHeight() + optList.scrollTop()) optList.scrollTop(optList.find("li.selected").position().top +
            optList.scrollTop() - optList.height() + optList.find("li.selected").outerHeight())
        }
        if ((e.keyCode == 13 || e.keyCode == 27) && replaced.hasClass(options.hoverClass)) {
          replaced.removeClass(options.hoverClass);
          optHolder.css({left: -9999, top: -9999})
        } else if (e.keyCode == 13 && !replaced.hasClass(options.hoverClass)) openDrop()
      };
      select.bind("change.customForm", changeSelect);
      select.get(0).onkeypress = changeSelect;
      select.bind("focus.customForm", function () {
        replaced.addClass("focus");
        select.attr("size", 4)
      }).bind("blur.customForm",
        function () {
          replaced.removeClass("focus");
          select.removeAttr("size")
        });
      select.data("customForm", {
        "resizeElement": function () {
          if (time) clearTimeout(time);
          time = setTimeout(function () {
            var w = 0;
            select.removeClass("outtaHere");
            $("div.selectArea.customSelect").css({display: "none"});
            w = Math.floor(select.outerWidth());
            select.addClass("outtaHere");
            $("div.selectArea.customSelect").css({display: "block"});
            replaced.width(w)
          }, 300)
        }, "create": replaced.add(optHolder)
      });
      $(window).bind("resize.customForm", function () {
        if (select.data("customForm")["resizeElement"]) select.data("customForm").resizeElement()
      })
    }).addClass("outtaHere")
  }

  function initRadio(elements, form, reset) {
    elements.each(function () {
      var radio = $(this);
      if (!radio.hasClass("outtaHere") && radio.is(":radio")) {
        radio.data("customRadio", {
          radio: radio,
          name: radio.attr("name"),
          label: $("label[for=" + radio.attr("id") + "]").length ? $("label[for=" + radio.attr("id") + "]") : radio.parents("label"),
          replaced: jQuery(options.radio.structure, {"class": radio.attr("class")})
        });
        radio.data("customRadio").replaced.addClass(radio.attr("class"));
        var data = radio.data("customRadio");
        if (radio.is(":disabled")) {
          data.replaced.addClass(options.disabled);
          if (radio.is(":checked")) data.replaced.addClass("disabledChecked")
        } else if (radio.is(":checked")) {
          data.replaced.addClass(options.radio.checked);
          data.label.addClass("checked")
        } else {
          data.replaced.addClass(options.radio.defaultArea);
          data.label.removeClass("checked")
        }
        data.replaced.click(function () {
          if (jQuery(this).hasClass(options.radio.defaultArea)) {
            radio.change();
            radio.prop("checked", true);
            changeRadio(data)
          }
        });
        reset.click(function () {
          setTimeout(function () {
            if (radio.is(":checked")) data.replaced.removeClass(options.radio.defaultArea +
              " " + options.radio.checked).addClass(options.radio.checked); else data.replaced.removeClass(options.radio.defaultArea + " " + options.radio.checked).addClass(options.radio.defaultArea)
          }, 10)
        });
        radio.bind("refresh", function () {
          if (radio.is(":checked")) {
            data.replaced.removeClass(options.radio.defaultArea + " " + options.radio.checked).addClass(options.radio.checked);
            data.label.addClass("checked")
          } else {
            data.replaced.removeClass(options.radio.defaultArea + " " + options.radio.checked).addClass(options.radio.defaultArea);
            data.label.removeClass("checked")
          }
        });
        radio.bind("click.customForm", function () {
          changeRadio(data)
        });
        radio.bind("focus.customForm", function () {
          data.replaced.addClass("focus")
        }).bind("blur.customForm", function () {
          data.replaced.removeClass("focus")
        });
        data.replaced.insertBefore(radio);
        radio.addClass("outtaHere");
        radio.data("customForm", {"create": data.replaced})
      }
    })
  }

  function changeRadio(data) {
    jQuery('input:radio[name="' + data.name + '"]').not(data.radio).each(function () {
      var _data = $(this).data("customRadio");
      if (_data.replaced &&
        !jQuery(this).is(":disabled")) {
        _data.replaced.removeClass(options.radio.defaultArea + " " + options.radio.checked).addClass(options.radio.defaultArea);
        _data.label.removeClass("checked")
      }
    });
    data.replaced.removeClass(options.radio.defaultArea + " " + options.radio.checked).addClass(options.radio.checked);
    data.label.addClass("checked");
    data.radio.trigger("change")
  }

  function initCheckbox(elements, form, reset) {
    elements.each(function () {
      var checkbox = $(this);
      if (!checkbox.hasClass("outtaHere") && checkbox.is(":checkbox")) {
        checkbox.data("customCheckbox",
          {
            checkbox: checkbox,
            label: $("label[for=" + checkbox.attr("id") + "]").length ? $("label[for=" + checkbox.attr("id") + "]") : checkbox.parents("label"),
            replaced: jQuery(options.checkbox.structure, {"class": checkbox.attr("class")})
          });
        checkbox.data("customCheckbox").replaced.addClass(checkbox.attr("class"));
        var data = checkbox.data("customCheckbox");
        if (checkbox.is(":disabled")) {
          data.replaced.addClass(options.disabled);
          if (checkbox.is(":checked")) data.replaced.addClass("disabledChecked")
        } else if (checkbox.is(":checked")) {
          data.replaced.addClass(options.checkbox.checked);
          data.label.addClass("checked")
        } else {
          data.replaced.addClass(options.checkbox.defaultArea);
          data.label.removeClass("checked")
        }
        data.replaced.click(function () {
          if (!data.replaced.hasClass("disabled") && !data.replaced.parents("label").length) {
            if (checkbox.is(":checked")) checkbox.prop("checked", false); else checkbox.prop("checked", true);
            changeCheckbox(data)
          }
        });
        reset.click(function () {
          setTimeout(function () {
            changeCheckbox(data)
          }, 10)
        });
        checkbox.bind("refresh", function () {
          if (checkbox.is(":checked")) {
            data.replaced.removeClass(options.checkbox.defaultArea +
              " " + options.checkbox.defaultArea).addClass(options.checkbox.checked);
            data.label.addClass("checked")
          } else {
            data.replaced.removeClass(options.checkbox.defaultArea + " " + options.checkbox.checked).addClass(options.checkbox.defaultArea);
            data.label.removeClass("checked")
          }
        });
        checkbox.bind("click.customForm", function () {
          changeCheckbox(data)
        });
        checkbox.bind("focus.customForm", function () {
          data.replaced.addClass("focus")
        }).bind("blur.customForm", function () {
          data.replaced.removeClass("focus")
        });
        data.replaced.insertBefore(checkbox);
        checkbox.addClass("outtaHere");
        checkbox.data("customForm", {"create": data.replaced, "events": data.replaced.parents("label")})
      }
    })
  }

  function changeCheckbox(data) {
    if (data.checkbox.is(":checked")) {
      data.replaced.removeClass(options.checkbox.defaultArea + " " + options.checkbox.defaultArea).addClass(options.checkbox.checked);
      data.label.addClass("checked")
    } else {
      data.replaced.removeClass(options.checkbox.defaultArea + " " + options.checkbox.checked).addClass(options.checkbox.defaultArea);
      data.label.removeClass("checked")
    }
    data.checkbox.trigger("change")
  }
};
