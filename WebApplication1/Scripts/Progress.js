document.onreadystatechange = function (e) {
    if (document.readyState == "interactive") {
        var all = document.getElementsByTagName("*");
        for (var i = 0, max = all.length; i < max; i++) {
            set_ele(all[i]);
        }
    }
}

function check_element(ele) {
    var all = document.getElementsByTagName("*");
    var totalele = all.length;
    var per_inc = 100 / all.length;

    if ($(ele).on()) {
        var prog_width = per_inc + Number(document.getElementById("progress_width").value);
        document.getElementById("progress_width").value = prog_width;
        console.log(prog_width);
        if (parseInt(prog_width) == 100) {
            var video = $("#myVid");
            video.load();
            if (typeof video !== 'undefined') {
                video[0].onprogress = function () {
                    startBuffer();
                }
            }
        }
    }

    else {
        set_ele(ele);
    }
}

function set_ele(set_element) {
    check_element(set_element);
}

function startBuffer() {
    var video = $("#myVid");
    var maxduration = video[0].duration;
    var currentBuffer = video[0].buffered.end(0);
    var percentage = 100 * currentBuffer / maxduration;
    $("#bar1").animate({ width: percentage + "%" }, 10);
    console.log(percentage);
}