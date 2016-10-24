;
(function ($) {
    $.extend({
        toJSON: function (arr) {
            if (arr == null) {
                return "[]";
            } else {
                var jsonResult = "[";
                for (var i = 0; i < arr.length; i++) {
                    //获得操作符
                    jsonResult += "{";
                    jsonResult += "'paraname':" + "'" + arr[i].name + "',";
                    var op = $("#" + arr[i].name + "Search").val();
                    if (op) {
                        jsonResult += "'searchop':" + "'" + op + "' ,";
                    }
                    jsonResult += "'paravalue':" + "'" + arr[i].value.trim() + "'},";
                }
                var result = jsonResult;
                if (result.trim().length > 1) {
                    result = result.substr(0, result.length - 1);
                }
                result += "]";
                return result;
            }
            return "[]";
        }
    });
})(jQuery);
(function ($, win) {
    /**
     * 窗口的帮助类用面向对象的方式组织自己的代码逻辑
     * @returns {} 
     */
    var windowhelper = (function () {
        var windowhelper = function () {
        };
        windowhelper.msgArr = {
            emptySelect: '请尚未选中任何要操作的记录!'
        };
        /**
         * 展示的窗口不管是添加还是修改都调用此方法
         * @returns {} 
         */
        windowhelper.showUI = function (htmlcontent, para, callback) {
            var heightwidth = para.AddWindow;
            layer.open({
                type: 1, //page层
                area: [heightwidth[0] + 'px', heightwidth[1] + 'px'],//['宽','高']
                title: para.AddTitle,
                shade: 0.6, //遮罩透明度
                moveType: 1, //拖拽风格，0是默认，1是传统拖动
                shift: -1, //0-6的动画形式，-1不开启
                content: htmlcontent,
                btn: para.AddBtn, //只是为了演示
                yes: function (index, layero) {
                    var v = $(para.FormId).validate({
                        submitHandler: function () {
                        }
                    });
                    if (v.form()) {
                        callback();
                        layer.close(index); //如果设定了yes回调，需进行手工关闭   
                    };
                },
                cancel: function () {
                    return true;
                }
            });
        };
        /**
         * 服务器返回时的数据提示
         * @param {} data 
         * @returns {} 
         */
        windowhelper.msgcall = function (data) {
            //layer.msg('ddddddddddddd', { icon: 6 });//1.对号2.错误3:问号4:锁屏5:不开心6:开心
            switch (data.status) {
                case "11-001":
                    layer.msg(data.msg, { icon: 6 });
                    break;
                case "11-002":
                case "11-003":
                case "11-004":
                    layer.msg(data.msg, { icon: 2 });
                    break;
            }
        };
        /**
         * 尚未选中数据
         * @returns {} 
         */
        windowhelper.emptySelect = function () {
            var that = this;
            layer.msg(that.msgArr.emptySelect, { icon: 5 });
        };
        /*闭包返回对应的函数*/
        return windowhelper;
    })();
    /**
     * crud操作的函数
     */
    var menucrud = (function () {
        var menucrud = function () {
            this.defaults = {
                'GridId': '#list4',
                'FormId': '#formui',
                'SearchForm': '#searchform',
                "GridPager": "#gridPager",
                'AddTitle': '添加',
                'EditTitle': '修改',
                'DeleteTitle': '删除',
                'DeleteText': '数据不可恢复,确认删除此项记录?',
                'AddWindow': [800, 400],//[宽，高]
                'EditWindow': [800, 400],
                'AddBtn': ['保存', '取消'],
                'PrimaryId': 'id'
            };
            this.AddUI = "../MenuinfoManager/AddUI";
            this.Add = "../MenuinfoManager/Add";
            this.EditUI = "../MenuinfoManager/EditUI";
            this.Edit = "../MenuinfoManager/Edit";
            this.DeleteUrl = "../MenuinfoManager/Delete";
        };
        menucrud.fn = menucrud.prototype;
        /**
         * 添加窗口要调用的函数
         * @returns {} 
         */
        menucrud.fn.AddUIWindow = function () {
            var that = this;
            $.ajax({
                type: "GET",
                url: that.AddUI,
                success: function (data) {
                    windowhelper.showUI(data, that.defaults, function () {
                        $.post(that.Add,
                        $(that.defaults.FormId).serialize(),
                        function (datacall) {
                            windowhelper.msgcall(datacall);
                            //刷新数据源
                            $(that.defaults.GridId).jqGrid('setGridParam', { search: true, mtype: 'POST' }).trigger("reloadGrid", [{ page: 1 }]);
                        });
                    });
                }
            });
        };
        /**
         * 编辑窗口调用的函数
         * @returns {} 
         */
        menucrud.fn.EditUIWindow = function () {
            var that = this;
            var priid = that.defaults.PrimaryId;
            var CurRow = $(that.defaults.GridId).getRowData(window.GridSelectedid);
            console.info(CurRow);
            var primaryid = CurRow[priid];
            if (primaryid) {
                $.ajax({
                    type: "GET",
                    url: that.EditUI,
                    data:{ id: primaryid },
                    success: function (data) {
                        var calback = function() {
                            $.post(that.Edit,
                            $(that.defaults.FormId).serialize(),
                            function (datacall) {
                                windowhelper.msgcall(datacall);
                                //刷新数据源
                                $(that.defaults.GridId).jqGrid('setGridParam', { search: true, mtype: 'POST' }).trigger("reloadGrid", [{ page: 1 }]);
                            });
                        };
                        windowhelper.showUI(data, that.defaults, calback);
                    }
                });
            } else {
                windowhelper.emptySelect();
            }
        };
        /**
         * 删除窗口调用的函数
         * @returns {} 
         */
        menucrud.fn.DeleteRecord = function () {
            var that = this;
            var priid = that.defaults.PrimaryId;
            var CurRow = $(that.defaults.GridId).getRowData(window.GridSelectedid);
            var primaryid = CurRow[priid];
            if (primaryid) {
                layer.confirm(that.defaults.DeleteText, {
                    title: '警告',
                    btn: ['确认', '取消'] //按钮
                }, function () {
                    layer.closeAll('dialog'); //关闭信息框
                    var callmethod = function (datares) {
                        windowhelper.msgcall(datares);
                        //刷新数据源
                        $(that.defaults.GridId).jqGrid('setGridParam', { search: true, mtype: 'POST' }).trigger("reloadGrid", [{ page: 1 }]);
                    };
                    $.post(that.DeleteUrl, { id: primaryid }, callmethod);
                }, function () {
                    swal("已取消", "您取消了删除操作！", "error");
                });
            } else {
                windowhelper.emptySelect();
            }
        };
        /**
         * 获得菜单的树形结构
         * @returns {} 
         */
        menucrud.fn.GetMenuTree = function () {
            layer.open({
                type: 2,
                title: '菜单父级选择窗口',
                shadeClose: true,
                shade: 0.3,
                area: ['400px', '500px'],
                content: '../MenuinfoManager/GetTree' //iframe的url
            });
        };
        /**
         * 获得菜单下按钮个数的界面
         * @returns {} 
         */
        menucrud.fn.GetActionTree = function () {
            var index = layer.open({
                type: 2,
                title: '分配操作行为窗口',
                shadeClose: true,
                shade: 0.3,
                area: ['700px', '500px'],
                content: '../MenuinfoManager/GetActionTree' //iframe的url
            });
            layer.full(index);
        };
        /**
         * 查询方法
         * @returns {} 
         */
        menucrud.fn.SearchMethod= function () {
            var that = this;
            var currentGrid = $(that.defaults.GridId);
            var postData = currentGrid.jqGrid("getGridParam", "postData");
            var otherData = $(that.defaults.SearchForm).serializeArray();
            otherData = $.toJSON(otherData);
            $.extend(postData, { customPar: otherData });
            currentGrid.jqGrid('setGridParam', { search: true, mtype: 'POST' }).trigger("reloadGrid", [{ page: 1 }]);
            return false;
        };
        return menucrud;
    })();
    /**
     * 接收树形结构的方法
     * @param {} nodeid 
     * @param {} nodename 
     * @returns {} 
     */
    win.RceiveTreeData = function (nodeid, nodename) {
        $("#pid").attr("value", nodeid);
        $("#pidname").val(nodename);
    };
    /**
     * 选中后的id
     */
    win.GridSelectedid = null;
    /*按钮注册事件的绑定*/
    $(function () {
        var crud = new menucrud();
        $("body").on("click", "button", function () {
            var curop = $(this).attr("op");
            switch (curop) {
                case "search":
                    crud.SearchMethod();
                    break;
                case "add":
                    crud.AddUIWindow();
                    break;
                case "delete":
                    crud.DeleteRecord();
                    break;
                case "edit":
                    crud.EditUIWindow();
                    break;
                case "menutree":
                    crud.GetMenuTree();
                    break;
                case "act"://分配操作行为的界面
                    crud.GetActionTree();
                    break;
            }
        });
    });
})(jQuery, window);