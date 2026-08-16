async function loadAppointments() {

    let response =
        await apiGet("/appointments");

    if (!response.ok) {

        alert("Cannot load appointments");
        return;

    }

    let appointments =
        await response.json();

    let html = "";
    appointments.forEach(a => {

        html += `

    <tr>

        <td>
            ${escapeHtml(a.doctorName ?? "Unknown")}
        </td>

        <td>
            ${escapeHtml(a.patientName ?? "Unknown")}
        </td>

        <td>
            ${a.appointmentDate
                ? escapeHtml(
                    new Date(a.appointmentDate).toLocaleString()
                )
                : ""
            }
        </td>

        <td class="status-${escapeHtml(a.status)}">
            ${escapeHtml(a.status)}
        </td>

        <td>
            ${escapeHtml(a.notes)}
        </td>

        <td>

            <button onclick="editAppointment(${Number(a.id)})">
                Update
            </button>

            <button onclick="deleteAppointment(${Number(a.id)})">
                Delete
            </button>

        </td>

    </tr>

    `;

    });

    document.getElementById("appointmentsTable").innerHTML = html;

}



async function loadDoctorsForAppointment() {

    let response =
        await apiGet("/doctors");

    if (!response.ok)
        return;

    let doctors =
        await response.json();

    let html =
        `<option value="">Select Doctor</option>`;

    doctors.forEach(d => {

        html += `

        <option value="${d.id}">
            ${d.firstName} ${d.lastName}
        </option>

        `;

    });

    document.getElementById("doctorId").innerHTML = html;

}



async function loadPatientsForAppointment() {

    let response =
        await apiGet("/patients");

    if (!response.ok)
        return;

    let patients =
        await response.json();

    let html =
        `<option value="">Select Patient</option>`;

    patients.forEach(p => {

        html += `

        <option value="${p.id}">
            ${p.firstName} ${p.lastName}
        </option>

        `;

    });

    document.getElementById("patientId").innerHTML = html;

}



function setMinAppointmentDate() {

    let input =
        document.getElementById("appointmentDate");

    if (input) {

        input.min =
            new Date()
                .toISOString()
                .slice(0, 16);

    }

}



async function createAppointment() {

    let appointment = {

        doctorId:
            Number(document.getElementById("doctorId").value),

        patientId:
            Number(document.getElementById("patientId").value),

        appointmentDate:
            document.getElementById("appointmentDate").value,

        status:
            "Scheduled",

        notes:
            document.getElementById("notes").value

    };

    let response =
        await apiPost("/appointments", appointment);

    if (response.ok) {

        alert("Appointment created successfully.");

        window.location =
            "/Appointments/Index";

    }
    else {

        alert(await response.text());

    }

}



async function loadAppointment() {

    let id = appointmentId;

    let response =
        await apiGet("/appointments/" + id);

    if (!response.ok) {

        alert("Appointment not found.");
        return;

    }

    let a =
        await response.json();

    await loadDoctorsForAppointment();

    await loadPatientsForAppointment();

    document.getElementById("doctorId").value =
        a.doctorId;

    document.getElementById("patientId").value =
        a.patientId;

    document.getElementById("appointmentDate").value =
        a.appointmentDate.substring(0, 16);

    document.getElementById("status").value =
        a.status;

    document.getElementById("notes").value =
        a.notes ?? "";

}



async function updateAppointment() {

    let id = appointmentId;

    let appointment = {

        doctorId:
            Number(document.getElementById("doctorId").value),

        patientId:
            Number(document.getElementById("patientId").value),

        appointmentDate:
            document.getElementById("appointmentDate").value,

        status:
            document.getElementById("status").value,

        notes:
            document.getElementById("notes").value

    };

    let response =
        await apiPut(
            "/appointments/" + id,
            appointment
        );

    if (response.ok) {

        alert("Appointment updated successfully.");

        window.location =
            "/Appointments/Index";

    }
    else {

        alert(await response.text("failed"));

    }

}



async function deleteAppointment(id) {

    if (!confirm("Delete this appointment?"))
        return;

    let response =
        await apiDelete("/appointments/" + id);

    if (response.ok) {

        alert("Appointment deleted.");

        loadAppointments();

    }
    else {

        alert("Delete failed.");

    }

}

async function editAppointment(id) {

    let response =
        await fetch(
            "/Appointments/ProtectId?id=" + id
        );


    let protectedId =
        await response.text();


    window.location =
        "/Appointments/Edit/" + protectedId;
}



if (location.pathname === "/Appointments/Index") {

    loadAppointments();

}



if (location.pathname === "/Appointments/Create") {

    loadDoctorsForAppointment();

    loadPatientsForAppointment();

    setMinAppointmentDate();

}



if (location.pathname.startsWith("/Appointments/Edit")) {

    loadAppointment();

}

