﻿let deleteBtns=document.querySelectorAll(".delete-btn")



deleteBtns.forEach(btn => btn.addEventListener("click", function (e) {
    e.preventDefault();
    let url = btn.getAttribute("href");
    console.log(url)
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(url)
                .then(response => {
                    if (response.status == 200) {
                        window.location.reload(true)
                    } else {
                        alert("tapilmadi")
                    }
                })
            //Swal.fire({
            //    title: "Deleted!",
            //    text: "Your file has been deleted.",
            //    icon: "success"
            //});
        }
    });
   
}))
let addToBasketBns = document.querySelectorAll(".add-to-basket");


addToBasketBns.forEach(btn => btn.addEventListener("click", function (e) {
    let url = btn.getAttribute("href");

    e.preventDefault();

    fetch(url)
        .then(response => {
            if (response.status == 200) {
                alert("Added to basket")
            } else {
                alert("error!")
            }
        })


}))