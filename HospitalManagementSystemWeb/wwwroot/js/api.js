const API_URL = "https://localhost:7156/api";


function getToken() {
    return sessionStorage.getItem("token");
}


function handleUnauthorized(response) {

    if (response.status === 401) {

        sessionStorage.removeItem("token");
        sessionStorage.removeItem("role");

        sessionStorage.setItem(
            "message",
            "Your session has expired. Please login again."
        );

        window.location.href = "/Authentication/Login";

        return true;
    }

    return false;
}


async function apiGet(endpoint) {

    const response = await fetch(
        API_URL + endpoint,
        {
            method: "GET",

            headers:
            {
                Authorization:
                    "Bearer " + getToken()
            }
        });

    if (handleUnauthorized(response))
        return null;

    return response;
}


async function apiPost(endpoint, data) {

    const response = await fetch(
        API_URL + endpoint,
        {
            method: "POST",

            headers:
            {
                "Content-Type": "application/json",

                Authorization:
                    "Bearer " + getToken()
            },

            body:
                JSON.stringify(data)
        });

    if (handleUnauthorized(response))
        return null;

    return response;
}


async function apiPut(endpoint, data) {

    const response = await fetch(
        API_URL + endpoint,
        {
            method: "PUT",

            headers:
            {
                "Content-Type": "application/json",

                Authorization:
                    "Bearer " + getToken()
            },

            body:
                JSON.stringify(data)
        });

    if (handleUnauthorized(response))
        return null;

    return response;
}


async function apiDelete(endpoint) {

    const response = await fetch(
        API_URL + endpoint,
        {
            method: "DELETE",

            headers:
            {
                Authorization:
                    "Bearer " + getToken()
            }
        });

    if (handleUnauthorized(response))
        return null;

    return response;
}