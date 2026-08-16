async function loadPatientHistory() {

    let patientId =
        document.getElementById("patientId").value;


    let response =
        await apiGet(
            "/patients/" + patientId + "/history"
        );


    if (!response.ok) {
        alert("Cannot load patient history");
        return;
    }


    let history =
        await response.json();



    let html = "";


    history.forEach(h => {

        html +=
            `
        <tr>

            <td>
                ${new Date(h.appointmentDate)
                .toLocaleString()}
            </td>


            <td>
                ${h.doctorName}
            </td>


            <td>
                ${h.status}
            </td>


            <td>
                ${h.notes ?? ""}
            </td>

        </tr>
        `;

    });



    document
        .getElementById("historyTable")
        .innerHTML = html;

}


loadPatientHistory();