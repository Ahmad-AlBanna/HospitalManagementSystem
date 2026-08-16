async function loadDashboard() {

    let response =
        await apiGet("/admin/dashboard");


    if (!response.ok) {
        console.log("Dashboard API failed");
        return;
    }


    let data =
        await response.json();


    document.getElementById("doctorCount")
        .textContent =
        data.doctors;


    document.getElementById("patientCount")
        .textContent =
        data.patients;


    document.getElementById("departmentCount")
        .textContent =
        data.departments;


    document.getElementById("appointmentCount")
        .textContent =
        data.appointments;

}


loadDashboard();