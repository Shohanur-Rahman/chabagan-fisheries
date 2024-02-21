import { Box, Button, Grid } from "@mui/material";
import { IconBreadcrumbs } from "../../../components/common/IconBreadcrumbs";
import LoadDataGrid from "../../../components/common/LoadDataGrid";
import breadCrumb from './../../../data/Breadcrumbs';
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import EditIcon from '@mui/icons-material/Edit';
import { useEffect, useState } from "react";
import { GridCellParams, GridColDef } from "@mui/x-data-grid";
import Swal from "sweetalert2";
import PaymentCollectionForm from "../../../components/stock/payment/PaymentCollectionForm";
import { IPaymentModel, MapPaymentModel } from "../../../interfaces/model/stock/IPaymentModel";
import { useDeletePaymentCollectionMutation, useGetPaymentCollectionMutation, useGetPaymetsQuery } from "../../../redux/features/stock/paymentCollectionApi";
import { ProjectTitle, showDeleteNotification, showErrorNotification } from "../../../data/Config";

export default function Payment() {
    const emptyModel: IPaymentModel = {
        id: 0,
        supplierId: 0,
        paymentCollectionType: 7,
        paidAmount: 0,
        billDate: new Date(),
        supplier: { label: "", value: "" }
    }

    const [rows, setRows] = useState([]);
    const { data, isSuccess } = useGetPaymetsQuery(null);
    const [getPaymentCollection, { isSuccess: isSingleSuccess, data: singleData, error: singleError }] = useGetPaymentCollectionMutation();
    const [deletePaymentCollection, { isSuccess: isDeleteSuccess, data: deleteData, error: deleteError }] = useDeletePaymentCollectionMutation();

    const [initialValues, setInitialValues] = useState<IPaymentModel>(emptyModel);
    const onEditClick = (row: GridCellParams) => {
        getPaymentCollection(row.id);
    }

    const onDeleteClickEvent = (row: GridCellParams) => {
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#d33",
            cancelButtonColor: "#3085d6",
            confirmButtonText: "Yes, delete it!"
        }).then((result) => {
            if (result.isConfirmed) {
                deletePaymentCollection(row.id);
            }
        });
    }

    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', filterable: true, headerClassName: "primary-header", flex: 1 },
        {
            field: 'billDate',
            headerName: 'Date',
            headerClassName: "primary-header",
            flex: 2
        },
        {
            field: 'supplierName',
            headerName: 'Supplier',
            headerClassName: "primary-header",
            flex: 3
        },
        {
            field: 'paidAmount',
            headerName: 'Amount',
            headerClassName: "primary-header",
            flex: 2
        },
        {
            field: 'note',
            headerName: 'Note',
            headerClassName: "primary-header",
            flex: 4
        },
        {
            field: 'action', flex: 2, headerName: 'Actions', headerClassName: "primary-header", renderCell: (params) => {
                return (
                    <>
                        <Button
                            className="grid-btn"
                            onClick={() => onEditClick(params.row)}
                            variant="contained"
                        >
                            <EditIcon className="f-16" />
                        </Button>
                        <Button
                            className="grid-btn"
                            onClick={() => onDeleteClickEvent(params.row)}
                            variant="contained"
                            color="error"
                        >
                            <DeleteForeverIcon className="f-16" />
                        </Button>
                    </>
                );
            }
        }
    ];

    useEffect(() => {
        if (isSuccess && data) {
            setRows(data?.result);
        }
    }, [data, isSuccess]);

    useEffect(() => {
        document.title = `Payments | ${ProjectTitle}`;
    }, []);

    useEffect(() => {
        if (singleError) {
            showErrorNotification();
        }
        else if (isSingleSuccess && singleData) {
            setInitialValues(MapPaymentModel(singleData.result))
        }
    }, [singleData, isSingleSuccess]);

    useEffect(() => {
        if (deleteError) {
            showErrorNotification();
        }
        else if (isDeleteSuccess && deleteData) {
            showDeleteNotification();
            setInitialValues(emptyModel);
        }
    }, [deleteData, isDeleteSuccess, deleteError]);

    return (
        <>
            <IconBreadcrumbs props={breadCrumb.paymentBreadCrumb} />
            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={4} lg={4}>
                        <PaymentCollectionForm typeId={7} info={initialValues} setState={setInitialValues} />
                    </Grid>

                    <Grid item xs={12} sm={12} md={8}>
                        <LoadDataGrid title="Payments" rows={rows} columns={columns} />
                    </Grid>
                </Grid>
            </Box>
        </>
    )
}