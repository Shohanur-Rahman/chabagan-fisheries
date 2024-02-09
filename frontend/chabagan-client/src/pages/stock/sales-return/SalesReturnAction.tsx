import { useFormik } from "formik";
import * as Yup from "yup";
import { Box, Button, Card, CardContent, CardHeader, Grid } from "@mui/material";
import DoneAllIcon from '@mui/icons-material/DoneAll';
import KeyboardDoubleArrowLeftIcon from '@mui/icons-material/KeyboardDoubleArrowLeft';
import { IconBreadcrumbs } from "../../../components/common/IconBreadcrumbs";
import salesBreadCrumb from '../../../data/Breadcrumbs';
import { useEffect, useState } from "react";
import { ProjectTitle, showAddNotification, showErrorNotification, showUpdateNotification } from "../../../data/Config";
import PurchaseInfo from "../../../components/stock/purchase/PurchaseInfo";
import PurchaseCalculation from "../../../components/stock/purchase/PurchaseCalculation";
import PurchaseForm from "../../../components/stock/purchase/PurchaseForm";
import { IPurchaseModel, MapPurchaseInfo } from "../../../interfaces/model/stock/IPurchaseModel";
import PurchaseItems from "../../../components/stock/purchase/PurchaseItems";
import { useNavigate, useParams } from "react-router-dom";
import { useAddSalesReturnMutation, useGetSalesReturnMutation, useUpdateSalesReturnMutation } from "../../../redux/features/stock/salesReturnApi";

export default function SalesReturnAction() {

    const [initialValues, setInitialValues] = useState<IPurchaseModel>(
        {
            id: 0,
            billNo: '',
            billDate: new Date(),
            supplierId: 0,
            totalAmount: 0,
            discount: 0,
            netAmount: 0,
            paidAmount: 0,
            duesAmount: 0,
            items: [],
            supplier: { label: '', value: '' },
            project: { label: '', value: '' },
            projectId: 0,
            note: ''
        }
    );
    const { id } = useParams();
    const navigate = useNavigate();
    const [addSalesReturn, { isLoading, isError, isSuccess, data, error }] = useAddSalesReturnMutation();
    const [updateSalesReturn, { isLoading: isUpdateLoading, isError: isUpdateError, isSuccess: isUpdateSuccess, data: updateData, error: updateError }] = useUpdateSalesReturnMutation();
    const [getSalesReturn, { isError: isPurchaseError, isSuccess: isPurchaseSuccess, data: purchaseData, error: purchaseError }] = useGetSalesReturnMutation();

    const validationSchema = Yup.object({
        billNo: Yup.string().required('Bill is required'),
        supplierId: Yup.number().min(1, 'Customer is required'),
        projectId: Yup.number().min(1, 'Project is required'),
        billDate: Yup.date().required('Date is required'),
        totalAmount: Yup.number().min(1, 'Total is required')
    });

    const formik = useFormik({
        initialValues: initialValues,
        enableReinitialize: true,
        validationSchema: validationSchema,
        validateOnBlur: false,
        validateOnChange: false,
        onSubmit: (values) => {
            if (values.id > 0) {
                updateSalesReturn(values);
            } else {
                addSalesReturn(values);
            }
        }
    });


    useEffect(() => {
        if (id) {
            document.title = `Edit Sales Return | ${ProjectTitle}`;
            getSalesReturn(id);
        } else {
            document.title = `New Sales Return | ${ProjectTitle}`;
        }

    }, [id]);

    useEffect(() => {
        if (isSuccess && data) {
            showAddNotification()
            navigate('/stock/sales-returns');
        }
        if (isError && error) {
            showErrorNotification(error);
        }
    }, [isSuccess, isError, data, error]);

    useEffect(() => {
        if (isUpdateSuccess && updateData) {
            showUpdateNotification()
            navigate('/stock/sales-returns');
        }
        if (isUpdateError && updateError) {
            showErrorNotification(updateError);
        }
    }, [isUpdateSuccess, isUpdateError, updateData, updateError]);

    useEffect(() => {
        if (isPurchaseError && purchaseError) {
            showErrorNotification(error);
        }
        else if (isPurchaseSuccess && purchaseData) {
            let editInfo = MapPurchaseInfo(purchaseData.result);
            setInitialValues(editInfo);
        }
    }, [isPurchaseSuccess, isPurchaseError, purchaseData, purchaseError]);

    return (
        <>
            {id ? (
                <IconBreadcrumbs props={salesBreadCrumb.editSalesReturnBreadCrumb} />
            ) : (
                <IconBreadcrumbs props={salesBreadCrumb.addSalesReturnBreadCrumb} />
            )}
            <Grid item xs={12} sm={12} md={12} mt={2}>
                <Box component="form" className="w-100 card-form" noValidate onSubmit={formik.handleSubmit}>
                    <Grid item xs={12} sm={12} md={12} lg={12}>
                        <Card sx={{ minWidth: 275 }} className="card w-100">
                            <CardHeader title={id ? "Edit Sales Return" : "New Sale Return"} className="card-header" />
                            <CardContent className="table-content">
                                <PurchaseInfo info={initialValues} formik={formik} setState={setInitialValues} mode="Customer" />
                                <PurchaseForm info={initialValues} setState={setInitialValues} />
                                <Grid container spacing={2} mt={0}>
                                    <Grid md={8} item xs={6}>
                                        <PurchaseItems info={initialValues} setState={setInitialValues} />
                                    </Grid>
                                    <PurchaseCalculation info={initialValues} formik={formik} setState={setInitialValues} />
                                </Grid>
                                <Grid item xs={12}>
                                    <hr />
                                </Grid>
                                <Grid item xs={12}>
                                    <Button variant="outlined" onClick={() => navigate(`/stock/sales-returns`)}> <KeyboardDoubleArrowLeftIcon />Back</Button>
                                    <Button type="submit"
                                        variant="contained"
                                        color="success"
                                        className="pull-right"
                                        disabled={(isLoading || isUpdateLoading)}
                                    >
                                        Save Changes &nbsp;<DoneAllIcon />
                                    </Button>
                                </Grid>
                            </CardContent>
                        </Card>
                    </Grid>
                </Box>
            </Grid>
        </>
    )
}