async function loadDepartments() {

    let response =
        await apiGet("/departments");

    if (!response.ok) {

        alert("Failed to load departments.");
        return;

    }

    let departments =
        await response.json();

    console.log(departments);

    let html = "";

    departments.forEach(d => {

        html += `
        <tr>

            <td>${d.name}</td>

            <td>
                <button onclick="deleteDepartment(${d.id})">
                    Delete
                </button>
            </td>

        </tr>
        `;

    });

    document
        .getElementById("departmentsTable")
        .innerHTML = html;

}



async function createDepartment() {

    let department = {

        name:
            document.getElementById("name").value

    };

    let response =
        await apiPost("/departments", department);

    if (response.ok) {

        alert("Department created successfully.");

        document.getElementById("name").value = "";

        loadDepartments();

    }
    else {

        let message =
            await response.text();

        alert(message);

    }

}



async function deleteDepartment(id) {

    let response =
        await apiDelete("/departments/" + id);

    if (response.ok) {

        alert("Department deleted successfully.");

        loadDepartments();

    }
    else {

        let message =
            await response.text();

        alert(message);

    }

}



if (location.pathname === "/Departments/Index") {

    loadDepartments();

}