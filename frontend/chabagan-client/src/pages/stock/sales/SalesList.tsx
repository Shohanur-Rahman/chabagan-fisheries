import { Button, Grid } from "@mui/material";
import AddIcon from '@mui/icons-material/Add';
import VisibilityIcon from '@mui/icons-material/Visibility';
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import EditIcon from '@mui/icons-material/Edit';
import { IconBreadcrumbs } from "../../../components/common/IconBreadcrumbs";
import salesBreadCrumb from '../../../data/Breadcrumbs';
import { useEffect, useState } from "react";
import { ApiBaseURL, ProjectTitle, showDeleteNotification, showErrorNotification } from "../../../data/Config";
import { useNavigate } from "react-router-dom";
import { GridCellParams, GridColDef } from "@mui/x-data-grid";
import Swal from "sweetalert2";
import dayjs from "dayjs";
import CustomPDFViwer from "../../../components/common/CustomPDFViwer";
import { IPdfViwerModel } from "../../../interfaces/model/IPdfViwerModel";
import { useDeleteSaleMutation, useGetSalesQuery } from "../../../redux/features/stock/SalesApi";
import LoadDataGrid from "../../../components/common/LoadDataGrid";

export default function SalesList() {
    const navigate = useNavigate();
    const [rows, setRows] = useState([]);
    const [viwer, setViwer] = useState({} as IPdfViwerModel);
    const { data, isSuccess } = useGetSalesQuery(null);
    const [deleteSale, { isSuccess: isDeleteSuccess, data: deleteData, error: deleteError }] = useDeleteSaleMutation();

    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', filterable: true, headerClassName: "primary-header", flex: 1 },
        {
            field: 'billNo',
            headerName: 'Bill',
            headerClassName: "primary-header",
            flex: 2
        },
        {
            field: 'billDate', headerName: 'Date', headerClassName: "primary-header", flex: 3, renderCell: (params) => {
                return (
                    <>
                        {dayjs(params.row?.billDate).format('DD MMM YYYY')}
                    </>
                );
            }
        },
        {
            field: 'supplierId', headerName: 'Supplier', headerClassName: "primary-header", flex: 4, renderCell: (params) => {
                return (
                    <>
                        {params.row?.supplier?.name}
                    </>
                );
            }
        },
        {
            field: 'projectId', headerName: 'Project', headerClassName: "primary-header", flex: 4, renderCell: (params) => {
                return (
                    <>
                        {params.row?.project?.name}
                    </>
                );
            }
        },
        {
            field: 'totalAmount',
            headerName: 'Total',
            headerClassName: "primary-header",
            flex: 2
        },
        {
            field: 'discount',
            headerName: 'Discount',
            headerClassName: "primary-header",
            flex: 2
        },
        {
            field: 'netAmount',
            headerName: 'Actual',
            headerClassName: "primary-header",
            flex: 2
        },
        {
            field: 'paidAmount',
            headerName: 'Paid',
            headerClassName: "primary-header",
            flex: 2
        },
        {
            field: 'duesAmount',
            headerName: 'Dues',
            headerClassName: "primary-header",
            flex: 2
        },
        {
            field: 'action', flex: 2, headerName: 'Actions', headerClassName: "primary-header", renderCell: (params) => {
                return (
                    <>
                        <Button
                            className="grid-btn"
                            onClick={() => onDownloadClick(params.row)}
                            variant="contained"
                        >
                            <VisibilityIcon className="f-16" />
                        </Button>
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

    const onDownloadClick = (row: any) => {
        let viwerInfo: IPdfViwerModel = {
            id: row.id.toString(),
            title: `Invoice no ${row?.billNo}`,
            url: `${ApiBaseURL}sales/invoice?id=${row.id}`,
            open: true
        }
        setViwer(viwerInfo);
    }

    const onEditClick = (row: GridCellParams) => {
        navigate(`/stock/sales/edit-sales/${row.id}`);
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
                deleteSale(row.id);
            }
        });
    }
    const handleAddClick = () => {
        navigate('/stock/sales/new-sales');
    }

    useEffect(() => {
        document.title = `Sales | ${ProjectTitle}`;
    }, []);

    useEffect(() => {
        if (isSuccess && data) {
            setRows(data?.result);
        }
    }, [data, isSuccess]);

    useEffect(() => {
        if (deleteError) {
            showErrorNotification();
        }
        else if (isDeleteSuccess && deleteData) {
            showDeleteNotification();
        }
    }, [deleteData, isDeleteSuccess, deleteError]);

    return (
        <>
            <IconBreadcrumbs props={salesBreadCrumb.salesBreadCrumb} />
            <Grid item xs={12} sm={12} md={12} mt={2} className="d-block">
                <Button variant="contained" className="pull-right" onClick={handleAddClick}><AddIcon /> &nbsp; New Sale</Button>
            </Grid>

            <Grid item xs={12} sm={12} md={12} mt={2}>
                <LoadDataGrid title="Sales" rows={rows} columns={columns} />
            </Grid>

            <CustomPDFViwer info={viwer} setState={setViwer} />
        </>
    )
}