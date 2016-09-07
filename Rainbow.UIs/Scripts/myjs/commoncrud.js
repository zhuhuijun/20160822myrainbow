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
(function ($, exports) {
    var crud = exports.crud || crud;
    /**
     * 操作路径的
     */
    var OptionObj = {
        EditUI: 'EditUI',
        Edit: 'Edit',
        AddUI: 'AddUI',
        Add: 'Add',
        DeleteUrl: 'Delete'
    };
    /**
     * 
     * 处理url
     * @param {} urls 
     * @returns {} 
     */
    var createurl = function (urls) {
        var res = ""
        if (urls.length < 1) {
            return res;
        } else {
            var urlarr = urls.split('/');
            for (var j = 0; j < urlarr.length - 1; j++) {
                res += urlarr[j] + "/";
            }
            return res;
        }
    }
    /**
     * 构造函数
     * @param {} getdataurl 
     * @param {} gridid 
     * @returns {} 
     */
    var CRUD = function (getdataurl, gridid) {
        this.GetDataUrl = getdataurl;
        this.GridId = gridid;
        //正则表达式获得GetData之前的路径截取出来
        var urlbase = createurl(getdataurl);
        this.EditUI = urlbase + OptionObj["EditUI"];
        this.Edit = urlbase + OptionObj["Edit"];
        this.AddUI = urlbase + OptionObj["AddUI"];
        this.Add = urlbase + OptionObj["Add"];
        this.DeleteUrl = urlbase + OptionObj["DeleteUrl"];
    };
    CRUD.fn = CRUD.prototype;
    /**
     * 查询方法的执行
     * @returns {} 
     */
    CRUD.fn.SearchMethod = function () {
        var that = this;
        var currentGrid = $(that.GridId);
        var postData = currentGrid.jqGrid("getGridParam", "postData");
        var otherData = $("#searchform").serializeArray();
        otherData = $.toJSON(otherData);
        $.extend(postData, { customPar: otherData });
        currentGrid.jqGrid('setGridParam', { search: true, mtype: 'POST' }).trigger("reloadGrid", [{ page: 1 }]);
        return false;
    };
    /**
     * 初始化表头的方法
     * @param {} coltitle 
     * @param {} cols 
     * @returns {} 
     */
    CRUD.fn.initTableCol = function (coltitle, cols) {
        var that = this;
        $(that.GridId).jqGrid({
            url: that.GetDataUrl,
            datatype: "json",
            mtype:'POST',
            height: 300,//高度，表格高度。可为数值、百分比或'auto'
            //width:1000,//这个宽度不能为百分比
            autowidth: true,//自动宽
            shrinkToFit: true,
            colNames: coltitle,
            colModel: cols,
            rownumbers: true,//添加左侧行号
            rowNum: 15,//每页显示记录数
            rowList: [15, 20, 25],//用于改变显示行数的下拉列表框的元素数组。
            onSelectRow: function (id) {

            },
            pager: $('#gridPager'),
            viewrecords: true,//是否在浏览导航栏显示记录总数
            // caption: "jqGrid 示例1",
            hidegrid: false
        });
        //绑定按钮的事件
        $("body").on("click", "button", function () {
            var curop = $(this).attr("op");
            switch(curop)
            {
                case "search":
                    that.SearchMethod();
                    break;
            }

        });
    };

    /**
     * 公布接口
     */
    exports.crud = CRUD;
})(jQuery, window);