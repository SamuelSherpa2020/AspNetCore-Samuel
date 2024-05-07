document.querySelector("#load-friends-button").addEventListener("click", async function () {
    try {
        // Fetch data from the server
        var response = await fetch("friends-list", { method: "GET" });

        // Extract the response text
        var responseBody = await response.text();

        // Update the HTML content of the list div
        document.querySelector("#list").innerHTML = responseBody;
    } catch (error) {
        console.error("Error fetching friends list:", error);
    }
});