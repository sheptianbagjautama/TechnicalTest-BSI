// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    // Tambah baris baru
    $("#addRow").click(function () {
        $("#transactionTable tbody").append(`
                            <tr>
                                        <td><input type="text" class="customerId form-control" /></td>
                                        <td><input type="date" class="transactionDate form-control" /></td>
                                        <td><button class="removeRow btn btn-danger">Hapus</button></td>
                            </tr>
                        `);
    });

    // Hapus baris
    $(document).on("click", ".removeRow", function () {
        $(this).closest("tr").remove();
    });

    // Simpan data transaksi
    $("#submit").click(function () {
        const transactions = [];
        $("#transactionTable tbody tr").each(function () {
            const customerId = $(this).find(".customerId").val();
            const transactionDate = $(this).find(".transactionDate").val();

            if (customerId && transactionDate) {
                transactions.push({
                    Customer_ID: customerId,
                    Transaction_Date: transactionDate
                });
            }
        });

        $.ajax({
            url: "/api/Transaction/AddTransactions",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(transactions),
            success: function () {
                alert("Data berhasil disimpan!");
            },
            error: function () {
                alert("Terjadi kesalahan saat menyimpan data.");
            }
        });
    });

    // Tampilkan penjualan terbanyak
    $("#getTopSales").click(function () {
        $.ajax({
            url: "/api/Transaction/GetTopSales",
            type: "GET",
            success: function (response) {

                let resultHtml = `
                        <h2>Output</h2>
                        <table class='table table-striped table-bordered'>
                        <tr class='text-center'>
                            <th>ID Pelanggan</th>
                            <th>Total Penjualan</th>
                        </tr>`;

                response.forEach(item => {
                    resultHtml +=
                        `<tr class='text-center'>
                                <td>${item.customer_ID}</td>
                                <td>${item.total_Penjualan}</td>
                            </tr>`;
                });

                resultHtml += "</table>";

                $("#result").html(resultHtml);
            },
            error: function () {
                alert("Terjadi kesalahan saat mengambil data.");
            }
        });
    });
});