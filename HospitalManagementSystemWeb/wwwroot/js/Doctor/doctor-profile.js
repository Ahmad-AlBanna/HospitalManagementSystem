async function loadDoctorProfile() {


    try {


        let response =
            await apiGet("/doctors/me");



        if (!response.ok) {

            alert("Cannot load profile");
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



        document
            .getElementById("specialization")
            .innerHTML =
            doctor.specialization ?? "-";



        document
            .getElementById("email")
            .innerHTML =
            doctor.email ?? "-";



        document
            .getElementById("phone")
            .innerHTML =
            doctor.phoneNumber ?? "-";



        document
            .getElementById("department")
            .innerHTML =
            doctor.departmentName ?? "-";


    }


    catch (error) {

        console.error(error);

        alert(
            "Something went wrong loading profile"
        );

    }


}



loadDoctorProfile();