async function loadDoctorProfile() {


    let response =
        await apiGet("/doctors/me");



    if (!response.ok) {

        alert("Cannot load doctor profile");
        return;

    }



    let doctor =
        await response.json();



    document
        .getElementById("doctorName")
        .innerHTML =
        doctor.firstName +
        " " +
        doctor.lastName;


}



async function loadDoctorAppointments() {


    let response =
        await apiGet("/appointments/my");



    if (!response.ok) {

        alert("Cannot load appointments");
        return;

    }



    let appointments =
        await response.json();



    // Total appointments

    document
        .getElementById("appointmentCount")
        .innerHTML =
        appointments.length;



    // Total unique patients

    let patients =
        new Set(
            appointments.map(a => a.patientId)
        );


    document
        .getElementById("patientCount")
        .innerHTML =
        patients.size;



    // Today's appointments

    let today =
        new Date()
            .toDateString();



    let todayAppointments =
        appointments.filter(a =>
            new Date(a.appointmentDate)
                .toDateString() === today
        );



    document
        .getElementById("todayAppointmentCount")
        .innerHTML =
        todayAppointments.length;



    loadTodayTable(todayAppointments);


}




function loadTodayTable(appointments) {


    let html = "";



    appointments.forEach(a => {


        html += `

        <tr>


            <td>
                ${a.patientName ?? "Unknown"}
            </td>


            <td>
                ${new Date(a.appointmentDate)
                .toLocaleTimeString([],
                    {
                        hour: "2-digit",
                        minute: "2-digit"
                    })
            }
            </td>


            <td>
                ${a.status}
            </td>


            <td>
                ${a.notes ?? ""}
            </td>


        </tr>

        `;


    });



    document
        .getElementById("todayAppointmentsTable")
        .innerHTML =
        html;


}




async function loadDashboard() {

    await loadDoctorProfile();

    await loadDoctorAppointments();

}



loadDashboard();