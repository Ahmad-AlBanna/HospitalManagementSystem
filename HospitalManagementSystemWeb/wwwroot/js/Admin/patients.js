async function loadPatients() {

    let response =
        await apiGet("/patients/paged");

    if (!response.ok) {
        alert("Failed to load patients.");
        return;
    }

    let patients =
        await response.json();

    console.log(patients);

    console.log(patients);
    console.log(Array.isArray(patients));

    let html = "";

    patients.items.forEach(p => {

        html += `

<tr>

    <td>
        ${escapeHtml(p.firstName)}
        ${escapeHtml(p.lastName)}
    </td>

    <td>
        ${escapeHtml(p.phoneNumber)}
    </td>

    <td>
        ${escapeHtml(p.email)}
    </td>

    <td>
        ${escapeHtml(p.address)}
    </td>

    <td>
        ${escapeHtml(p.gender)}
    </td>

    <td>
        ${escapeHtml(p.dateOfBirth)}
    </td>

    <td>

        <button onclick="deletePatient(${Number(p.id)})">
            Delete
        </button>

    </td>

</tr>

`;

    });

    document
        .getElementById("patientsTable")
        .innerHTML = html;
}


async function createPatient() {

    let patient = {

        firstName:
            document.getElementById("firstName").value,

        lastName:
            document.getElementById("lastName").value,

        phoneNumber:
            document.getElementById("phoneNumber").value,

        email:
            document.getElementById("email").value,

        address:
            document.getElementById("address").value,

        gender:
            document.getElementById("gender").value,

        dateOfBirth:
            document.getElementById("dateOfBirth").value

    };

    let response =
        await apiPost("/patients", patient);

    if (response.ok) {

        alert("Patient created successfully.");

        window.location = "/Patients/Index";

    } else {

        let message =
            await response.text();

        alert(message);
    }
}
function loadGenders() {

    let html = `
        <option value="">
            Select Gender
        </option>

        <option value="Male">
            Male
        </option>

        <option value="Female">
            Female
        </option>
    `;

    document.getElementById("gender").innerHTML = html;

}

async function deletePatient(id) {

    let response =
        await apiDelete("/patients/" + id);

    if (response.ok) {

        alert("Patient deleted successfully.");

        loadPatients();

    }
    else {

        alert("Failed to delete patient.");

    }

    loadPatients();
}


// Page loading

if (location.pathname === "/Patients/Index") {
    loadPatients();
}

if (location.pathname === "/Patients/Create") {

    loadGenders();

    document.getElementById("dateOfBirth").max =
        new Date().toISOString().split("T")[0];

}