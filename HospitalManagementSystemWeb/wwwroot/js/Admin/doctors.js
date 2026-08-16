async function loadDoctors() {


    let response =
        await apiGet("/doctors");


    if (!response.ok) {

        alert("Failed to load doctors.");
        return;

    }


    let doctors =
        await response.json();



    console.log(doctors);



    let html = "";



    doctors.forEach(d => {

        html +=
            `
    <tr>

        <td>
            ${escapeHtml(d.firstName)}
            ${escapeHtml(d.lastName)}
        </td>


        <td>
            ${escapeHtml(d.email)}
        </td>


        <td>
            ${escapeHtml(d.specialization)}
        </td>


        <td>
            ${escapeHtml(d.phoneNumber)}
        </td>


        <td>
            ${escapeHtml(d.departmentId)}
        </td>


        <td>

            <button onclick="deleteDoctor(${Number(d.id)})">
                Delete
            </button>

        </td>

    </tr>
    `;

    });


    document
        .getElementById("doctorsTable")
        .innerHTML = html;

}


async function loadDepartments() {

    let response = await apiGet("/departments");


    if (!response.ok) {

        alert("Cannot load departments.");
        return;

    }


    let departments = await response.json();


    console.log(departments);


    let html =
        `<option value="">Select Department</option>`;


    departments.forEach(d => {

        html += `
<option value="${d.id}">
    ${d.name}
</option>
`;

    });


    document.getElementById("departmentId").innerHTML = html;

}




async function createDoctor() {

    let doctor = {

        username: document.getElementById("username").value,

        passwordHash:
            document.getElementById("password").value,

        firstName:
            document.getElementById("firstName").value,

        lastName:
            document.getElementById("lastName").value,

        specialization:
            document.getElementById("specialization").value,

        departmentId:
            Number(document.getElementById("departmentId").value),

        phoneNumber:
            document.getElementById("phoneNumber").value,

        email:
            document.getElementById("email").value,

        address:
            document.getElementById("address").value

    };


    let response =
        await apiPost("/doctors", doctor);



    if (response.ok) {
        alert("Doctor created successfully.");

        window.location = "/Doctors/Index";
    }
    else {
        let message =
            await response.text("something went wrong");

        alert(message);
    }

}




async function deleteDoctor(id) {


    let response =
        await apiDelete(
        "/doctors/" + id
    );


    if (response.ok) {

        alert("Doctor deleted successfully.");

        loadDoctors();

    }
    else {

        alert("Failed to delete Doctor.");

    }

    loadDoctors();

}



// Page loading

if (location.pathname === "/Doctors/Index") {
    loadDoctors();
}


if (location.pathname === "/Doctors/Create") {
    loadDepartments();
}