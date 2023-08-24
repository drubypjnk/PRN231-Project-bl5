
var token = localStorage.getItem("token");

//$.ajax({
//    url: "http://localhost:5225/api/User/GetUseras",
//    headers: { "Authorization": "Bearer " + token },
//    success: function (roles) {
//        if (!roles.includes("Admin")) {
//            window.location.href = "http://localhost:5171/AccessDenied";
//        }
//    },
//    error: function (error) {
//        console.error("Failed to fetch user roles:", error);
//    }
//});
// Function to update user greeting
function updateGreeting(username) {
    $("#userGreeting").text("Xin chào! " + username);
}

var storedUsername = localStorage.getItem("username");
if (storedUsername) {
    updateGreeting(storedUsername);
}

// Handle login button click
$("#loginButton").click(function () {
    var username = $("#username").val();
    var password = $("#password").val();

    var requestData = {
        username: username,
        password: password
    };

    $.ajax({
        type: "POST",
        url: "http://localhost:5225/api/Authen/Login",
        contentType: "application/json",
        data: JSON.stringify(requestData),
        success: function (response) {
            // Cập nhật thông báo chào mừng
            updateGreeting(username);

            // Lưu token vào localStorage

            localStorage.setItem("token", response);
            localStorage.setItem("username", username);
            console.log("Token and username saved to localStorage.");

            // Di chuyển đến trang /Admin
            window.location.href = "/Sku";
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Login failed: " + errorThrown);
        }
    });
});

var storedToken = localStorage.getItem("token");

// Chọn tất cả các nút đăng nhập và đăng ký bằng class "login-button"
var loginButtons = $(".login-button");

// Chọn nút "Logout" bằng class "logout-button"
var logoutButton = $(".logout-button");

// Nếu có token, ẩn nút đăng nhập và đăng ký, hiển thị nút "Logout"
if (storedToken) {
    loginButtons.hide();
    logoutButton.show();
} else {
    // Ngược lại, hiển thị nút đăng nhập và đăng ký, ẩn nút "Logout"
    loginButtons.show();
    logoutButton.hide();
}

$("#logoutButton").click(function () {
    logout();
});
function logout() {
    $.ajax({
        type: "POST",
        url: "http://localhost:5225/api/Authen/Logout",
        success: function (response) {
            // Xóa token và tên người dùng khỏi localStorage
            localStorage.removeItem("token");
            localStorage.removeItem("username");
            // Di chuyển đến trang đăng nhập hoặc trang chính
            window.location.href = "http://localhost:5171"; // Đổi thành đường dẫn của trang đăng nhập hoặc trang chính
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Logout failed: " + errorThrown);
        }
    });
}







