function SortTable(n,is_namber) {
    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById("myTable");
    switching = true;

    dir = "asc";

    while (switching) {

        switching = false;
        rows = table.getElementsByTagName("TR");

        for (i = 1; i < (rows.length - 1); i++) {

            shouldSwitch = false;

            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];


            if (dir == "asc") {
                if (is_namber) {
                    if (+x.innerHTML.replace(',', '.') > +y.innerHTML.replace(',', '.')) {
                        shouldSwitch = true;
                        break;
                    }

                }
                else if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            }
            else if (dir == "desc") {
                if (is_namber) {
                    if (+x.innerHTML.replace(',', '.') < +y.innerHTML.replace(',', '.')) {
                        shouldSwitch = true;
                        break;
                    }
                }
                else if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {

            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;

            switchcount++;
        } else {

            if (switchcount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }
}

function Search() {
    var rows, i, search;

    rows = document.getElementById("myTable").getElementsByTagName("TR");
    search = document.getElementById("search").value;
    for (i =1; i < rows.length; i++) {

        if (rows[i].getElementsByTagName("TD")[1].innerHTML.toLowerCase().includes(search.toLowerCase())) {
            rows[i].style.display = "table-row";
        }
        else {
            rows[i].style.display = "none";
        }
    }    
}

function DeleteBook(id) {

    var rows = document.getElementById("myTable").getElementsByTagName("TR");
    for (i = 1; i < rows.length; i++) {

        if (rows[i].getElementsByTagName("TD")[0].innerHTML == id) {
            rows[i].remove();
        }
        $.ajax({
            type: "POST",
            url: "/Home/DeleteAsync",
            data: { 'id': id },
            success: function () {
                console.log("Deleted " + id);
            }
        });
    }   
}