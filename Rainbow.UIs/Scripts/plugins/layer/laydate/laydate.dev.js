/**

@Name : layDate v1.1 日期控件
@Author: 贤心
@Date: 2014-06-25
@QQ群：176047195
@Site：http://sentsin.com/layui/laydate

 * @date 2016-06-12
 * @author kenneth huang<kennethhuang@live.cn> 
 * 
 * 
 * Ver    变更日期              负责人  变更内容
 * ───────────────────────────────────
 * V0.01  2016/06/12 18:36:00   黄鑫    初版，修复 format
 *
 * Copyright (c) Yu Qian Technology Co. Ltd. All rights reserved.
 *┌──────────────────────────────────┐
 *│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
 *│　版权所有：榆钱（北京）科技有限公司　　　　　　          　　　　　│
 *└──────────────────────────────────┘
 */

; !function (win) {

    //全局配置，如果采用默认均不需要改动
    var config = {
        path: "/js/plugins/layer/laydate/", //laydate所在路径
        skin: "shenlv", //初始化皮肤
        format: "MM-DD-YYYY", //日期格式
        min: "1900-01-01 00:00:00", //最小日期
        max: "2099-12-31 23:59:59", //最大日期
        isv: false,
        init: false
    };

    var dates = {}, doc = document, creat = "createElement", byid = "getElementById", tags = "getElementsByTagName";
    var as = ["laydate_box", "laydate_void", "laydate_click", "LayDateSkin", "skins/", "/laydate.css"];


    //主接口
    win.laydate = function (options) {
        options = options || {};
        try {
            as.event = win.event ? win.event : laydate.caller.arguments[0];
        } catch (e) { };
        dates.run(options);

        return laydate;
    };

    laydate.v = "1.1";

    //获取组件存放路径
    //dates.getPath = (function () {
    //    var js = document.scripts, jsPath = js[js.length - 1].src;
    //    return config.path ? config.path : jsPath.substring(0, jsPath.lastIndexOf("/") + 1);
    //}());

    dates.use = function (lib, id) {
        var link = doc[creat]("link");
        link.type = "text/css";
        link.rel = "stylesheet";
        link.href = config.path + lib + as[5];
        id && (link.id = id);
        doc[tags]("head")[0].appendChild(link);
        //link = null;
    };

    dates.trim = function (str) {
        str = str || "";
        return str.replace(/^\s|\s$/g, "").replace(/\s+/g, " ");
    };

    //补齐数位
    dates.digit = function (num) {
        // debugger;
        return num < 10 ? "0" + (num | 0) : num;
    };

    dates.stopmp = function (e) {
        e = e || win.event;
        e.stopPropagation ? e.stopPropagation() : e.cancelBubble = true;
        return this;
    };

    dates.each = function (arr, fn) {
        var i = 0, len = arr.length;
        for (; i < len; i++) {
            if (fn(i, arr[i]) === false) {
                break;
            }
        }
    };

    dates.hasClass = function (elem, cls) {
        elem = elem || {};
        return new RegExp('\\b' + cls + '\\b').test(elem.className);
    };

    dates.addClass = function (elem, cls) {
        elem = elem || {};
        dates.hasClass(elem, cls) || (elem.className += ' ' + cls);
        elem.className = dates.trim(elem.className);
        return this;
    };

    dates.removeClass = function (elem, cls) {
        elem = elem || {};
        if (dates.hasClass(elem, cls)) {
            var reg = new RegExp('\\b' + cls + '\\b');
            elem.className = elem.className.replace(reg, '');
        }
        return this;
    };

    //清除css属性
    dates.removeCssAttr = function (elem, attr) {
        var s = elem.style;
        if (s.removeProperty) {
            s.removeProperty(attr);
        } else {
            s.removeAttribute(attr);
        }
    };

    //显示隐藏
    dates.shde = function (elem, type) {
        debugger;
        elem.style.display = type ? 'none' : 'block';
    };

    //简易选择器
    dates.query = function (node) {
        if (node && node.nodeType === 1) {
            if (node.tagName.toLowerCase() !== 'input') {
                throw new Error('选择器elem错误');
            }
            return node;
        }
        node = (dates.trim(node)).split(' ');
        var elemId = doc[byid](node[0].substr(1)), arr;
        if (!elemId) {
            return "";     //??????????
        } else if (!node[1]) {
            return elemId;
        } else if (/^\./.test(node[1])) {
            var find, child = node[1].substr(1), exp = new RegExp('\\b' + child + '\\b');
            arr = [];
            find = doc.getElementsByClassName ? elemId.getElementsByClassName(child) : elemId[tags]('*');
            dates.each(find, function (ii, that) {
                exp.test(that.className) && arr.push(that);
            });
            return arr[0] ? arr : '';
        } else {
            arr = elemId[tags](node[1]);
            return arr[0] ? elemId[tags](node[1]) : '';
        }
    };

    //事件监听器
    dates.on = function (elem, even, fn) {
        //debugger;
        elem.attachEvent ? elem.attachEvent('on' + even, function () {
            fn.call(elem, win.even);
        }) : elem.addEventListener(even, fn, false);
        return dates;
    };

    //阻断mouseup
    dates.stopMosup = function (evt, elem) {
        if (evt !== 'mouseup') {
            dates.on(elem, 'mouseup', function (ev) {
                dates.stopmp(ev);
            });
        }
    };

    dates.run = function (options) {
        // debugger;
        var s = dates.query, devt, even = as.event, target;
        try {
            target = even.target || even.srcElement || {};
        } catch (e) {
            target = {};
        }
        var elem = options.elem ? s(options.elem) : target;

        as.elemv = /textarea|input/.test(elem.tagName.toLocaleLowerCase()) ? 'value' : 'innerHTML';
        if (('init' in options ? options.init : config.init) && (!elem[as.elemv])) elem[as.elemv] = laydate.now(null, options.format || config.format);

        if (even && target.tagName) {
            if (!elem || elem === dates.elem) {
                return;
            }
            dates.stopMosup(even.type, elem);
            dates.stopmp(even);
            dates.view(elem, options);
            dates.reshow();
        } else {
            devt = options.event || 'click';
            dates.each((elem.length | 0) > 0 ? elem : [elem], function (ii, that) {
                dates.stopMosup(devt, that);
                dates.on(that, devt, function (ev) {
                    dates.stopmp(ev);
                    if (that !== dates.elem) {
                        dates.view(that, options);
                        dates.reshow();
                    }
                });
            });
        }

        laydate.skin(options.skin || config.skin);
    };

    dates.scroll = function (type) {
        type = type ? 'scrollLeft' : 'scrollTop';
        return doc.body[type] | doc.documentElement[type];
    };

    dates.winarea = function (type) {
        return document.documentElement[type ? 'clientWidth' : 'clientHeight'];
    };

    //判断闰年
    dates.isleap = function (year) {
        return (year % 4 === 0 && year % 100 !== 0) || year % 400 === 0;
    };

    //检测是否在有效期
    dates.checkVoid = function (yy, mm, dd) {
        //debugger;
        var back = [];
        yy = yy | 0;
        mm = mm | 0;
        dd = dd | 0;
        if (yy < dates.mins[0]) {
            back = ["y"];
        } else if (yy > dates.maxs[0]) {
            back = ["y", 1];
        } else if (yy >= dates.mins[0] && yy <= dates.maxs[0]) {
            if (yy === dates.mins[0]) {
                if (mm < dates.mins[1]) {
                    back = ["m"];
                } else if (mm === dates.mins[1]) {
                    if (dd < dates.mins[2]) {
                        back = ["d"];
                    }
                }
            }
            if (yy === dates.maxs[0]) {
                if (mm > dates.maxs[1]) {
                    back = ["m", 1];
                } else if (mm === dates.maxs[1]) {
                    if (dd > dates.maxs[2]) {
                        back = ["d", 1];
                    }
                }
            }
        }
        return back;
    };

    //时分秒的有效检测
    dates.timeVoid = function (times, index) {
        if (dates.ymd[1] + 1 === dates.mins[1] && dates.ymd[2] === dates.mins[2]) {
            if (index === 0 && (times < dates.mins[3])) {
                return 1;
            } else if (index === 1 && times < dates.mins[4]) {
                return 1;
            } else if (index === 2 && times < dates.mins[5]) {
                return 1;
            }
        } else if (dates.ymd[1] + 1 === dates.maxs[1] && dates.ymd[2] === dates.maxs[2]) {
            if (index === 0 && times > dates.maxs[3]) {
                return 1;
            } else if (index === 1 && times > dates.maxs[4]) {
                return 1;
            } else if (index === 2 && times > dates.maxs[5]) {
                return 1;
            }
        }
        if (times > (index ? 59 : 23)) {
            return 1;
        }
        return 0;
    };

    //检测日期是否合法
    dates.check = function () {
        // debugger;
        var reg = dates.options.format.replace(/YYYY|MM|DD|hh|mm|ss/g, "\\d+\\").replace(/\\$/g, "");
        var exp = new RegExp(reg), value = dates.elem[as.elemv];
        var arr = value.match(/\d+/g) || [];

        var format = (dates.options.format || config.format).split("-");
        format[2] = format[2].split(" ")[0];

        var isvoid = dates.checkVoid(arr[format.indexOf("YYYY")], arr[format.indexOf("MM")], arr[format.indexOf("DD")]);

        if (value.replace(/\s/g, "") !== "") {
            if (!exp.test(value)) {
                dates.elem[as.elemv] = "";
                dates.msg("日期不符合格式，请重新选择。");
                return 1;
            } else if (isvoid[0]) {
                dates.elem[as.elemv] = "";
                dates.msg("日期不在有效期内，请重新选择。");
                return 1;
            } else {
                isvoid.value = dates.elem[as.elemv].match(exp).join();

                if (arr[format.indexOf("MM")] < 1) {
                    arr[format.indexOf("MM")] = 1;
                    isvoid.auto = 1;
                } else if (arr[format.indexOf("MM")] > 12) {
                    arr[format.indexOf("MM")] = 12;
                    isvoid.auto = 1;
                } else if (arr[format.indexOf("MM")].length < 2) {
                    isvoid.auto = 1;
                }
                if (arr[format.indexOf("DD")] < 1) {
                    arr[format.indexOf("DD")] = 1;
                    isvoid.auto = 1;
                } else if (arr[format.indexOf("DD")] > dates.months[(arr[format.indexOf("MM")] | 0) - 1]) {
                    arr[format.indexOf("DD")] = 31;
                    isvoid.auto = 1;
                } else if (arr[format.indexOf("DD")].length < 2) {
                    isvoid.auto = 1;
                }
                if (arr.length > 3) {
                    if (dates.timeVoid(arr[3], 0)) {
                        isvoid.auto = 1;
                    };
                    if (dates.timeVoid(arr[4], 1)) {
                        isvoid.auto = 1;
                    };
                    if (dates.timeVoid(arr[5], 2)) {
                        isvoid.auto = 1;
                    };
                }
                if (isvoid.auto) {
                    dates.creation([arr[format.indexOf("YYYY")], arr[format.indexOf("MM")] | 0, arr[format.indexOf("DD")] | 0], 1);
                } else if (isvoid.value !== dates.elem[as.elemv]) {
                    dates.elem[as.elemv] = isvoid.value;
                }
            }
        }

        return 0;
    };

    //生成日期
    dates.months = [31, null, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    dates.viewDate = function (y, m, d) {
        //debugger;
        var log = {}, de = new Date();
        y < (dates.mins[0] | 0) && (y = (dates.mins[0] | 0));
        y > (dates.maxs[0] | 0) && (y = (dates.maxs[0] | 0));

        de.setFullYear(y, m, d);
        log.ymd = [de.getFullYear(), de.getMonth(), de.getDate()];

        dates.months[1] = dates.isleap(log.ymd[0]) ? 29 : 28;

        de.setFullYear(log.ymd[0], log.ymd[1], 1);
        log.FDay = de.getDay();

        log.PDay = dates.months[m === 0 ? 11 : m - 1] - log.FDay + 1;
        log.NDay = 1;

        //渲染日
        dates.each(as.tds, function (i, elem) {
            var yy = log.ymd[0], mm = log.ymd[1] + 1, dd;
            elem.className = '';
            if (i < log.FDay) {
                elem.innerHTML = dd = i + log.PDay;
                dates.addClass(elem, 'laydate_nothis');
                mm === 1 && (yy -= 1);
                mm = mm === 1 ? 12 : mm - 1;
            } else if (i >= log.FDay && i < log.FDay + dates.months[log.ymd[1]]) {
                elem.innerHTML = dd = i - log.FDay + 1;
                if (i - log.FDay + 1 === log.ymd[2]) {
                    dates.addClass(elem, as[2]);
                    log.thisDay = elem;
                }
            } else {
                elem.innerHTML = dd = log.NDay++;
                dates.addClass(elem, 'laydate_nothis');
                mm === 12 && (yy += 1);
                mm = mm === 12 ? 1 : mm + 1;
            }

            if (dates.checkVoid(yy, mm, dd)[0]) {
                dates.addClass(elem, as[1]);
            }

            dates.options.festival && dates.festival(elem, mm + '.' + dd);
            elem.setAttribute('y', yy);
            elem.setAttribute('m', mm);
            elem.setAttribute('d', dd);
            // yy = mm = dd = null;
        });

        dates.valid = !dates.hasClass(log.thisDay, as[1]);
        dates.ymd = log.ymd;

        //锁定年月
        //as.year.value = dates.ymd[0] + '年';
        //as.month.value = dates.digit(dates.ymd[1] + 1) + '月';
        as.year.value = dates.ymd[0];
        as.month.value = dates.month(dates.ymd[1]);

        //定位月
        dates.each(as.mms, function (i, elem) {
            var getCheck = dates.checkVoid(dates.ymd[0], (elem.getAttribute('m') | 0) + 1);
            if (getCheck[0] === 'y' || getCheck[0] === 'm') {
                dates.addClass(elem, as[1]);
            } else {
                dates.removeClass(elem, as[1]);
            }
            dates.removeClass(elem, as[2]);
            // getCheck = null;
        });
        dates.addClass(as.mms[dates.ymd[1]], as[2]);

        //定位时分秒
        log.times = [
            dates.inymd[3] | 0 || 0,
            dates.inymd[4] | 0 || 0,
            dates.inymd[5] | 0 || 0
        ];
        dates.each(new Array(3), function (i) {
            dates.hmsin[i].value = dates.digit(dates.timeVoid(log.times[i], i) ? dates.mins[i + 3] | 0 : log.times[i] | 0);
        });

        //确定按钮状态
        dates[dates.valid ? 'removeClass' : 'addClass'](as.ok, as[1]);
    };
    // 月
    dates.month = function (b) {
        var ii = null;
        switch (b) {
            case 0:
                ii = "Jan";
                break;
            case 1:
                ii = "Feb";
                break;
            case 2:
                ii = "Mar";
                break;
            case 3:
                ii = "Apr";
                break;
            case 4:
                ii = "May";
                break;
            case 5:
                ii = "Jun";
                break;
            case 6:
                ii = "Jul";
                break;
            case 7:
                ii = "Aug";
                break;
            case 8:
                ii = "Sep";
                break;
            case 9:
                ii = "Oct";
                break;
            case 10:
                ii = "Nov";
                break;
            case 11:
                ii = "Dec";
                break;
        }
        return ii;
    };

    //节日
    //dates.festival = function (td, md) {
    //    var str;
    //    switch (md) {
    //        case '1.1':
    //            str = '元旦';
    //            break;
    //        case '3.8':
    //            str = '妇女';
    //            break;
    //        case '4.5':
    //            str = '清明';
    //            break;
    //        case '5.1':
    //            str = '劳动';
    //            break;
    //        case '6.1':
    //            str = '儿童';
    //            break;
    //        case '9.10':
    //            str = '教师';
    //            break;
    //        case '10.1':
    //            str = '国庆';
    //            break;
    //    };
    //    str && (td.innerHTML = str);
    //   // str = null;
    //};

    //生成年列表
    dates.viewYears = function (yy) {
        var s = dates.query, str = '';
        dates.each(new Array(14), function (i) {
            if (i === 7) {
                str += '<li ' + (parseInt(as.year.value) === yy ? 'class="' + as[2] + '"' : '') + ' y="' + yy + '">' + yy + '</li>';
            } else {
                str += '<li y="' + (yy - 7 + i) + '">' + (yy - 7 + i) + '</li>';
            }
        });
        s('#laydate_ys').innerHTML = str;
        dates.each(s('#laydate_ys li'), function (i, elem) {
            if (dates.checkVoid(elem.getAttribute('y'))[0] === 'y') {
                dates.addClass(elem, as[1]);
            } else {
                dates.on(elem, 'click', function (ev) {
                    dates.stopmp(ev).reshow();
                    dates.viewDate(this.getAttribute('y') | 0, dates.ymd[1], dates.ymd[2]);
                });
            }
        });
    };

    //初始化面板数据
    dates.initDate = function () {
        //debugger;
        var format = (dates.options.format || config.format).split("-");
        format[2] = format[2].split(" ")[0];

        var de = new Date();
        var ymd = dates.elem[as.elemv].match(/\d+/g) || [];
        if (ymd.length < 3) {
            ymd = dates.options.start.match(/\d+/g) || [];
            if (ymd.length < 3) {
                //ymd = [de.getFullYear(), de.getMonth() + 1, de.getDate()];
                ymd = [0, 0, 0];
                ymd[format.indexOf("YYYY")] = de.getFullYear();
                ymd[format.indexOf("MM")] = de.getMonth() + 1;
                ymd[format.indexOf("DD")] = de.getDate();
            }
        }
        dates.inymd = ymd;


        var y = ymd[format.indexOf("YYYY")];
        var m = ymd[format.indexOf("MM")] - 1;
        var d = ymd[format.indexOf("DD")];

        dates.viewDate(y, m, d);
    };

    //是否显示零件
    dates.iswrite = function () {
        var s = dates.query, log = {
            time: s('#laydate_hms')
        };
        dates.shde(log.time, !dates.options.istime);
        dates.shde(as.oclear, !('isclear' in dates.options ? dates.options.isclear : 1));
        dates.shde(as.otoday, !('istoday' in dates.options ? dates.options.istoday : 1));
        dates.shde(as.ok, !('issure' in dates.options ? dates.options.issure : 1));
    };

    //方位辨别
    dates.orien = function (obj, pos) {
        //debugger;
        var tops, rect = dates.elem.getBoundingClientRect();
        obj.style.left = rect.left + (pos ? 0 : dates.scroll(1)) + 'px';
        if (rect.bottom + obj.offsetHeight / 1.5 <= dates.winarea()) {
            tops = rect.bottom - 1;
        } else {
            tops = rect.top > obj.offsetHeight / 1.5 ? rect.top - obj.offsetHeight + 1 : dates.winarea() - obj.offsetHeight;
        }
        obj.style.top = Math.max(tops + (pos ? 0 : dates.scroll()), 1) + 'px';
    };

    //吸附定位
    dates.follow = function (obj) {
        //debugger;
        if (dates.options.fixed) {
            obj.style.position = 'fixed';
            dates.orien(obj, 1);
        } else {
            obj.style.position = 'absolute';
            dates.orien(obj);
        }
    };

    //生成表格
    dates.viewtb = (function () {
        var tr, view = [], weeks = ["Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"]; // ['日', '一', '二', '三', '四', '五', '六'];
        var log = {}, table = doc[creat]('table'), thead = doc[creat]('thead');
        thead.appendChild(doc[creat]('tr'));
        log.creath = function (i) {
            var th = doc[creat]('th');
            th.innerHTML = weeks[i];
            thead[tags]('tr')[0].appendChild(th);
            // th = null;
        };

        dates.each(new Array(6), function (i) {
            view.push([]);
            tr = table.insertRow(0);
            dates.each(new Array(7), function (j) {
                view[i][j] = 0;
                i === 0 && log.creath(j);
                tr.insertCell(j);
            });
        });

        table.insertBefore(thead, table.children[0]);
        table.id = table.className = 'laydate_table';
        tr = view = null;
        return table.outerHTML;//.toLowerCase();
    }());

    //渲染控件骨架
    dates.view = function (elem, options) {
        //debugger;
        var s = dates.query, div, log = {};
        options = options || elem;
        dates.elem = elem;
        dates.options = options;
        dates.options.format || (dates.options.format = config.format);
        dates.options.start = dates.options.start || '';
        dates.mm = log.mm = [dates.options.min || config.min, dates.options.max || config.max];
        dates.mins = log.mm[0].match(/\d+/g);
        $.each(dates.mins, function (i, item) {
            dates.mins[i] = parseInt(item);
        });
        dates.maxs = log.mm[1].match(/\d+/g);
        $.each(dates.maxs, function (i, item) {
            dates.maxs[i] = parseInt(item);
        });
        debugger;
        if (!dates.box) {
            if (doc.getElementById(as[0]) === null) {

                //#region div


                div = doc[creat]('div');
                div.id = as[0];
                div.className = as[0];
                div.style.cssText = 'position: absolute;';
                div.setAttribute('name', 'laydate-v' + laydate.v);

                div.innerHTML = log.html = '<div class="laydate_top">'
                  + '<div class="laydate_ym laydate_y" id="laydate_YY">'
                    + '<a class="laydate_choose laydate_chprev laydate_tab"><cite></cite></a>'
                    + '<input id="laydate_y" readonly><label></label>'
                    + '<a class="laydate_choose laydate_chnext laydate_tab"><cite></cite></a>'
                    + '<div class="laydate_yms">'
                      + '<a class="laydate_tab laydate_chtop"><cite></cite></a>'
                      + '<ul id="laydate_ys"></ul>'
                      + '<a class="laydate_tab laydate_chdown"><cite></cite></a>'
                    + '</div>'
                  + '</div>'
                  + '<div class="laydate_ym laydate_m" id="laydate_MM">'
                    + '<a class="laydate_choose laydate_chprev laydate_tab"><cite></cite></a>'
                    + '<input id="laydate_m" readonly><label></label>'
                    + '<a class="laydate_choose laydate_chnext laydate_tab"><cite></cite></a>'
                    + '<div class="laydate_yms" id="laydate_ms">' + function () {
                        var str = '';
                        dates.each(new Array(12), function (i) {
                            //str += '<span m="' + i + '">' + dates.digit(i + 1) + '月</span>';
                            str += '<span m="' + i + '">' + dates.month(i) + '</span>';

                        });
                        return str;
                    }() + '</div>'
                  + '</div>'
                + '</div>'

                + dates.viewtb

                + '<div class="laydate_bottom">'
                  + '<ul id="laydate_hms">'
                    + '<li class="laydate_sj">time</li>'
                    + '<li><input readonly>:</li>'
                    + '<li><input readonly>:</li>'
                    + '<li><input readonly></li>'
                  + '</ul>'
                  + '<div class="laydate_time" id="laydate_time"></div>'
                  + '<div class="laydate_btn">'
                    + '<a id="laydate_clear">Clear</a>'
                    + '<a id="laydate_today">Today</a>'
                    + '<a id="laydate_ok">OK</a>'
                  + '</div>'
                  + (config.isv ? '<a href="http://sentsin.com/layui/laydate/" class="laydate_v" target="_blank">laydate-v' + laydate.v + '</a>' : '')
                + '</div>';

                //#endregion

                doc.body.appendChild(div);
                dates.box = s('#' + as[0]);
                dates.events();
                div = null;
            } else {
                dates.box = s('#' + as[0]);
                dates.events();
                dates.shde(dates.box);
            }


        } else {
            dates.shde(dates.box);
        }
        dates.follow(dates.box);
        options.zIndex ? dates.box.style.zIndex = options.zIndex : dates.removeCssAttr(dates.box, 'z-index');
        dates.stopMosup('click', dates.box);

        dates.initDate();
        dates.iswrite();
        dates.check();
    };

    //隐藏内部弹出元素
    dates.reshow = function () {
        debugger;
        dates.each(dates.query('#' + as[0] + ' .laydate_show'), function (i, elem) {
            dates.removeClass(elem, 'laydate_show');
        });
        return this;
    };

    //关闭控件
    dates.close = function () {
        debugger;
        dates.reshow();
        dates.shde(dates.query('#' + as[0]), 1);
        dates.elem = null;
    };

    //转换日期格式
    dates.parse = function (ymd, hms, format) {
        //debugger;
        ymd = ymd.concat(hms);
        format = format || (dates.options ? dates.options.format : config.format);

        return format.replace(/YYYY|MM|DD|hh|mm|ss/g, function (str) {
            ymd.index = ++ymd.index | 0;
            switch (str) {
                case "YYYY":
                    return dates.digit(ymd[0]);
                case "MM":
                    return dates.digit(ymd[1]);
                case "DD":
                    return dates.digit(ymd[2]);
                default:
                    return dates.digit(ymd[ymd.index]);
            }

        });
    };

    //返回最终日期
    dates.creation = function (ymd, hide) {
        //debugger;
        var hms = dates.hmsin;
        var getDates = dates.parse(ymd, [hms[0].value, hms[1].value, hms[2].value]);
        dates.elem[as.elemv] = getDates;
        if (!hide) {
            dates.close();
            typeof dates.options.choose === 'function' && dates.options.choose(getDates);
        }
    };

    //事件
    dates.events = function () {
        var s = dates.query, log = {
            box: '#' + as[0]
        };

        dates.addClass(doc.body, 'laydate_body');

        as.tds = s('#laydate_table td');
        as.mms = s('#laydate_ms span');
        as.year = s('#laydate_y');
        as.month = s('#laydate_m');

        //显示更多年月
        dates.each(s(log.box + ' .laydate_ym'), function (i, elem) {
            dates.on(elem, 'click', function (ev) {
                dates.stopmp(ev).reshow();
                dates.addClass(this[tags]('div')[0], 'laydate_show');
                if (!i) {
                    log.YY = parseInt(as.year.value);
                    dates.viewYears(log.YY);
                }
            });
        });

        dates.on(s(log.box), 'click', function () {
            dates.reshow();
        });

        //切换年
        log.tabYear = function (type) {
            if (type === 0) {
                dates.ymd[0]--;
            } else if (type === 1) {
                dates.ymd[0]++;
            } else if (type === 2) {
                log.YY -= 14;
            } else {
                log.YY += 14;
            }
            if (type < 2) {
                dates.viewDate(dates.ymd[0], dates.ymd[1], dates.ymd[2]);
                dates.reshow();
            } else {
                dates.viewYears(log.YY);
            }
        };
        dates.each(s('#laydate_YY .laydate_tab'), function (i, elem) {
            dates.on(elem, 'click', function (ev) {
                dates.stopmp(ev);
                log.tabYear(i);
            });
        });


        //切换月
        log.tabMonth = function (type) {
            if (type) {
                dates.ymd[1]++;
                if (dates.ymd[1] === 12) {
                    dates.ymd[0]++;
                    dates.ymd[1] = 0;
                }
            } else {
                dates.ymd[1]--;
                if (dates.ymd[1] === -1) {
                    dates.ymd[0]--;
                    dates.ymd[1] = 11;
                }
            }
            dates.viewDate(dates.ymd[0], dates.ymd[1], dates.ymd[2]);
        };
        dates.each(s('#laydate_MM .laydate_tab'), function (i, elem) {
            dates.on(elem, 'click', function (ev) {
                dates.stopmp(ev).reshow();
                log.tabMonth(i);
            });
        });

        //选择月
        dates.each(s('#laydate_ms span'), function (i, elem) {
            dates.on(elem, 'click', function (ev) {
                dates.stopmp(ev).reshow();
                if (!dates.hasClass(this, as[1])) {
                    dates.viewDate(dates.ymd[0], this.getAttribute('m') | 0, dates.ymd[2]);
                }
            });
        });

        //选择日
        dates.each(s('#laydate_table td'), function (i, elem) {
            dates.on(elem, 'click', function (ev) {
                if (!dates.hasClass(this, as[1])) {
                    dates.stopmp(ev);
                    dates.creation([this.getAttribute('y') | 0, this.getAttribute('m') | 0, this.getAttribute('d') | 0]);
                }
            });
        });

        //清空
        as.oclear = s('#laydate_clear');
        dates.on(as.oclear, 'click', function () {
            dates.elem[as.elemv] = '';
            dates.close();
        });

        //今天
        as.otoday = s('#laydate_today');
        dates.on(as.otoday, 'click', function () {
            var now = new Date();
            dates.creation([now.getFullYear(), now.getMonth() + 1, now.getDate()]);
        });

        //确认
        as.ok = s('#laydate_ok');
        dates.on(as.ok, 'click', function () {
            if (dates.valid) {
                dates.creation([dates.ymd[0], dates.ymd[1] + 1, dates.ymd[2]]);
            }
        });

        //选择时分秒
        log.times = s('#laydate_time');
        dates.hmsin = log.hmsin = s('#laydate_hms input');
        log.hmss = ['小时', '分钟', '秒数'];
        log.hmsarr = [];

        //生成时分秒或警告信息
        dates.msg = function (i, title) {
            var str = '<div class="laydte_hsmtex">' + (title || '提示') + '<span>×</span></div>';
            if (typeof i === 'string') {
                str += '<p>' + i + '</p>';
                dates.shde(s('#' + as[0]));
                dates.removeClass(log.times, 'laydate_time1').addClass(log.times, 'laydate_msg');
            } else {
                if (!log.hmsarr[i]) {
                    str += '<div id="laydate_hmsno" class="laydate_hmsno">';
                    dates.each(new Array(i === 0 ? 24 : 60), function (i) {
                        str += '<span>' + i + '</span>';
                    });
                    str += '</div>';
                    log.hmsarr[i] = str;
                } else {
                    str = log.hmsarr[i];
                }
                dates.removeClass(log.times, 'laydate_msg');
                dates[i === 0 ? 'removeClass' : 'addClass'](log.times, 'laydate_time1');
            }
            dates.addClass(log.times, 'laydate_show');
            log.times.innerHTML = str;
        };

        log.hmson = function (input, index) {
            var span = s('#laydate_hmsno span'), set = dates.valid ? null : 1;
            dates.each(span, function (i, elem) {
                if (set) {
                    dates.addClass(elem, as[1]);
                } else if (dates.timeVoid(i, index)) {
                    dates.addClass(elem, as[1]);
                } else {
                    dates.on(elem, 'click', function () {
                        if (!dates.hasClass(this, as[1])) {
                            input.value = dates.digit(this.innerHTML | 0);
                        }
                    });
                }
            });
            dates.addClass(span[input.value | 0], 'laydate_click');
        };

        //展开选择
        dates.each(log.hmsin, function (i, elem) {
            dates.on(elem, 'click', function (ev) {
                dates.stopmp(ev).reshow();
                dates.msg(i, log.hmss[i]);
                log.hmson(this, i);
            });
        });

        dates.on(doc, 'mouseup', function () {
            var box = s('#' + as[0]);
            if (box && box.style.display !== 'none') {
                dates.check() || dates.close();
            }
        }).on(doc, 'keydown', function (event) {
            event = event || win.event;
            var codes = event.keyCode;

            //如果在日期显示的时候按回车
            if (codes === 13 && dates.elem) {
                dates.creation([dates.ymd[0], dates.ymd[1] + 1, dates.ymd[2]]);
            }
        });
    };

    dates.init = (function () {
        dates.use('need');
        dates.use(as[4] + config.skin, as[3]);
        dates.skinLink = dates.query('#' + as[3]);
    }());

    //重置定位
    laydate.reset = function () {
        (dates.box && dates.elem) && dates.follow(dates.box);
    };

    //返回指定日期
    laydate.now = function (timestamp, format) {
        debugger;
        var de = new Date((timestamp | 0) ? function (tamp) {
            return tamp < 86400000 ? (+new Date + tamp * 86400000) : tamp;
        }(parseInt(timestamp)) : +new Date);
        return dates.parse(
            [de.getFullYear(), de.getMonth() + 1, de.getDate()],
            [de.getHours(), de.getMinutes(), de.getSeconds()],
            format
        );
    };

    //皮肤选择
    laydate.skin = function (lib) {
        dates.skinLink.href = config.path + as[4] + lib + as[5];
    };

}(window);