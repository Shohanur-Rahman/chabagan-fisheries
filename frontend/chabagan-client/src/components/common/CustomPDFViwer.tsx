import { Box, Button, Modal } from "@mui/material";
import { IPdfViwerModel } from "../../interfaces/model/IPdfViwerModel";
import { SetStateAction } from "react";
import CloseIcon from '@mui/icons-material/Close';

const style = {
    position: 'absolute' as 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
};

const CustomPDFViwer: React.FC<{
    info: IPdfViwerModel,
    setState: React.Dispatch<SetStateAction<IPdfViwerModel>>
}> = ({ info, setState }) => {

    const closeModal = () => {
        setState((prevState) => ({
            ...prevState,
            open: false
        }));
    }
    return (
        <Modal
            open={info.open}
            aria-labelledby="modal-modal-title"
            aria-describedby="modal-modal-description"
            className="lg-modal"
        >
            <Box sx={style} className="mdl-box">
                <Box>
                    <iframe className='full-frame' title={info.title} src={info.url} />
                </Box>
                <Box mt={1}>
                    <Button variant="outlined" onClick={closeModal} className="pull-right"> <CloseIcon />Close</Button>
                </Box>
            </Box>
        </Modal>

    )

}

export default CustomPDFViwer;