async function login() {

    try {

        const response = await fetch(
            "https://localhost:7156/api/authentication/login",
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    email: document.getElementById("email").value,
                    password: document.getElementById("password").value
                })
            });


        if (!response.ok) {
            const errorData = await response.json();

            alert(errorData.message || "Login failed");

            return;
        }


        const data = await response.json();


        sessionStorage.setItem("token", data.accessToken);
        sessionStorage.setItem("role", data.user.roleId);


        if (sessionStorage.getItem("role") === "1")
            window.location = "/Admin/Dashboard";
        else
            window.location = "/Doctor/Index";

    }
    catch (err) {

        console.error(err);
        alert("Cannot connect to the API.");

    }
}



document.addEventListener("DOMContentLoaded", function () {

    const message = sessionStorage.getItem("message");

    if (message) {

        const messageDiv =
            document.getElementById("sessionMessage");

        if (messageDiv) {
            messageDiv.innerText = message;
            messageDiv.style.display = "block";
        }

        sessionStorage.removeItem("message");
    }

});


