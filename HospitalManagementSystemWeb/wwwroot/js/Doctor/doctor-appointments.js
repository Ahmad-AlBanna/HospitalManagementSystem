async function loadDoctorAppointments() {

    let response =
        await apiGet("/appointments/my");


    if (!response.ok) {

        alert("Cannot load appointments.");
        return;

    }


    let appointments =
        await response.json();


    let html = "";


    appointments.forEach(a => {

        html += `

        <tr>

            <td>
                ${a.patientName ?? "Unknown"}
            </td>


            <td>
                ${a.appointmentDate
                ? new Date(a.appointmentDate).toLocaleString()
                : ""
            }
            </td>


            <td>

                <select id="status-${a.id}">

                    <option value="Scheduled"
                        ${a.status === "Scheduled" ? "selected" : ""}>
                        Scheduled
                    </option>

                    <option value="Completed"
                        ${a.status === "Completed" ? "selected" : ""}>
                        Completed
                    </option>

                    <option value="Cancelled"
                        ${a.status === "Cancelled" ? "selected" : ""}>
                        Cancelled
                    </option>

                </select>

            </td>


            <td>

                <textarea id="notes-${a.id}">${a.notes ?? ""}</textarea>

            </td>


            <td>

                <button onclick="viewPatientHistory(${a.patientId})">
                    History
                </button>

                <button onclick="updateAppointment(${a.id})">
                    Update
                </button>

            </td>

        </tr>

        `;

    });


    document
        .getElementById("appointmentsTable")
        .innerHTML = html;

}



async function updateAppointment(id) {

    let appointment = {

        status:
            document
                .getElementById("status-" + id)
                .value,

        notes:
            document
                .getElementById("notes-" + id)
                .value

    };


    let response =
        await apiPut(
            "/appointments/" + id + "/doctor-update",
            appointment
        );


    if (response.ok) {

        alert("Appointment updated successfully.");

        loadDoctorAppointments();

    }
    else {

        alert(await response.text());

    }

}



async function viewPatientHistory(patientId) {

    console.log("Patient ID:", patientId);

    let url =
        "/Appointments/ProtectId?id=" + patientId;

    console.log("URL:", url);

    let response =
        await fetch(url);

    console.log("Status:", response.status);

    if (!response.ok) {

        let message = await response.text();
        console.log(message);

        alert("Cannot protect patient id");
        return;

    }

    let protectedId =
        await response.text();

    window.location =
        "/Doctor/PatientHistory/" + protectedId;

}



loadDoctorAppointments();